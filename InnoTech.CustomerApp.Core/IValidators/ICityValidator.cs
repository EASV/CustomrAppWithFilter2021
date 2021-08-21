using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Core.IValidators
{
    public interface ICityValidator
    {
        void DefaultValidation(City city);
    }
}