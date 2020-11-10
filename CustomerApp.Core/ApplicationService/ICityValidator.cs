using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICityValidator
    {
        public void DefaultValidation(City city);
    }
}