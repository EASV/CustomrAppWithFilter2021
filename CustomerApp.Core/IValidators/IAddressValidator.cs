using CustomerApp.Core.Models;

namespace CustomerApp.Core.IValidators
{
    public interface IAddressValidator
    {
        void DefaultValidation(Address address);
    }
}