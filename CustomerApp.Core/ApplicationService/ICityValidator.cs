using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICityValidator
    {
        void DefaultValidation(City city);
    }
}