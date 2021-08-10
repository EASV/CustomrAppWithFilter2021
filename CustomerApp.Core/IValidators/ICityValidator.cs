using CustomerApp.Core.Models;

namespace CustomerApp.Core.IValidators
{
    public interface ICityValidator
    {
        void DefaultValidation(City city);
    }
}