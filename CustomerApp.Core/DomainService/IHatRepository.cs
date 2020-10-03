using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface IHatRepository
    {
        public List<Hat> ReadAll();
        public List<HatType> ReadAllTypes();
        public List<Brand> ReadAllBrands();
        public List<Color> ReadAllColors();
        public Hat Update(Hat hat);
        public Hat Create(Hat hat);
    }
}