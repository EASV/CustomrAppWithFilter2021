using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface IAddressValidator
    {
        void DefaultValidation(Address address);
    }
}