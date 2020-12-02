using System.Transactions;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.DomainService;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerApp.Infrastructure.SQL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbContextTransaction _transaction;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        public UnitOfWork(
            CustomerAppDBContext ctx,
            ICityRepository cityRepository, 
            ICountryRepository countryRepository)
        { 
            _transaction = ctx.Database.BeginTransaction();
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        public ICityRepository CityRepository() { return _cityRepository; }

        public ICountryRepository CountryRepository() { return _countryRepository; }

        public void SaveChanges()
        {
            _transaction.Commit();
        }
    }
}