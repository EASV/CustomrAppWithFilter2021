using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface IBrandRepository
    {
        public Brand Create(Brand brand);
    }
}