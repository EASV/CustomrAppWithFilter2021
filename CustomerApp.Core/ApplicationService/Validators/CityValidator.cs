using System;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Validators
{
    public class CityValidator: ICityValidator
    {
        public void DefaultValidation(City city)
        {
            ValidateName(city);
        }

        private void ValidateName(City city)
        {
            if(city == null) {throw new NullReferenceException("City Cannot be Null");}
            if (string.IsNullOrEmpty(city.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if (city.Name.Length < 3)
            {
                throw new ArgumentException("Name must be more then 2 chars");
            }
            if (city.Name.Length > 25)
            {
                throw new ArgumentException("Name Cannot be more then 25 chars");
            }

            
        }
    }
}