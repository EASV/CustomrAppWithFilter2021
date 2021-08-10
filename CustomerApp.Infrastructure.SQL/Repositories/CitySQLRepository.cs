using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CustomerApp.Core.Exceptions;
using CustomerApp.Core.Models;
using CustomerApp.Core.Persistance.Interfaces;
using CustomerApp.Infrastructure.SQL.Converters;
using CustomerApp.Infrastructure.SQL.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.SQL.Repositories
{
    public class CitySQLRepository: ICityRepository
    {
        private readonly CustomerAppDBContext _ctx;
        private readonly IMapper _mapper;
        public CitySQLRepository(CustomerAppDBContext ctx)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<City, CitySql>().ConvertUsing(new CityToCitySqlConverter());
                cfg.CreateMap<CitySql, City>().ConvertUsing(new CitySqlToCityConverter());
            });
            configuration.AssertConfigurationIsValid();
            _mapper = configuration.CreateMapper();
            _ctx = ctx;
        }
        public List<City> GetAll()
        {   return _ctx.Cities
                .Include(c => c.Tourists)
                .ThenInclude(ct => ct.Tourist)
                .Include(c => c.Country)
                .Select(c => _mapper.Map<CitySql, City>(c))
                .ToList();
        }

        public City Create(City city)
        {
            try
            {
                var cityEntry = _ctx.Add(_mapper.Map<City, CitySql>(city));
                _ctx.SaveChanges();
                var newCity = cityEntry.Entity;
                return _mapper.Map<CitySql, City>(newCity);
            }
            catch (Exception e)
            {
                throw new DataSourceException(e.InnerException?.Message);
            }
            
        }
        
        public void CreateAll(List<City> cities)
        {
            if (cities != null)
            {
                _ctx.AddRange(cities.Select(city => _mapper.Map<City, CitySql>(city)));
                _ctx.SaveChanges();
            }
        }

        public City ReadById(int cityZipCode)
        {
            return _ctx.Cities.Select(c => new City()
            {
                ZipCode = c.ZipCode,
                Country = new Country
                {
                    Id = c.CountryId
                },
                Name = c.Name,
                TouristsVisits = c.Tourists.Select(ct => new TouristVisit()
                {
                    Tourist = new Tourist {
                        Id = ct.Tourist.Id,
                        Name = ct.Tourist.Name
                    },
                    VisitTime = ct.VisitDate
                }).ToList()
            }).FirstOrDefault(city => city.ZipCode == cityZipCode);
        }

        public City Delete(int zipCode)
        {
            _ctx.CityTourists.RemoveRange(_ctx.CityTourists.Where(ct => ct.CityId == zipCode));
            var entry = _ctx.Remove(new City(){ZipCode = zipCode});
            _ctx.SaveChanges();
             return entry.Entity;
        }

        public City Update(City cityToUpdate)
        {
            // 1: Get rid of all current rows with CityId 7002
            _ctx.CityTourists.RemoveRange(_ctx.CityTourists.Where(ct => ct.CityId == cityToUpdate.ZipCode));
            // 2: Adding All new Relations to CityTourist
            _ctx.CityTourists.AddRange(cityToUpdate.TouristsVisits.Select(t => 
                new CityTouristSql(){CityId = cityToUpdate.ZipCode, TouristId = t.Tourist.Id, VisitDate = t.VisitTime}));
            // 3: Saving updates
            var entry = _ctx.Update(cityToUpdate);
            _ctx.SaveChanges();
            return entry.Entity;
        }
    }
}