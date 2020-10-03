using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface IHatTypeRepository
    {
        public HatType Create(HatType brand);
    }
}