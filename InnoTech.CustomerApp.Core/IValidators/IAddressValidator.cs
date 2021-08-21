using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Core.IValidators
{
    public interface IAddressValidator
    {
        void DefaultValidation(Address address);
    }
}