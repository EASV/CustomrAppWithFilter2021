using System.Threading.Tasks;
using CustomerApp.Core.DomainService;

namespace CustomerApp.Core.ApplicationService
{
    public interface IUnitOfWork
    {
        public ICityRepository CityRepository();
        public ICountryRepository CountryRepository();
        void SaveChanges();
    }
}