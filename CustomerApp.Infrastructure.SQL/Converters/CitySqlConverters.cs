using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.SQL.DBEntities;

namespace CustomerApp.Infrastructure.SQL.Converters
{
    public class CitySqlToCityConverter : ITypeConverter<CitySql, City>
    {
        public City Convert(CitySql c, City destination, ResolutionContext context)
        {
            return new City()
            {
                ZipCode = c.ZipCode,
                Country = new Country
                {
                    Id = c.Country != null ? c.Country.Id : 0,
                    Name = c.Country != null ? c.Country.Name : ""
                },
                Name = c.Name,
                TouristsVisits = c.Tourists
                    .Select(ct => new TouristVisit()
                    {
                        Tourist = new Tourist
                        {
                            Id = ct.Tourist.Id,
                            Name = ct.Tourist.Name
                        },
                        VisitTime = ct.VisitDate
                    }).ToList()
            };
        }
    }
    
    public class CityToCitySqlConverter : ITypeConverter<City, CitySql>
    {
        public CitySql Convert(City city, CitySql destination, ResolutionContext context)
        {
            return new CitySql()
            {
                CountryId = city.Country.Id,
                Name = city.Name,
                ZipCode = city.ZipCode,
                Tourists = city.TouristsVisits == null ? new List<CityTouristSql>() : 
                    city.TouristsVisits.Select(t => new CityTouristSql
                    {
                        TouristId = t.Tourist.Id, CityId = city.ZipCode, VisitDate = t.VisitTime
                    }).ToList()
            };
        }
    }
}