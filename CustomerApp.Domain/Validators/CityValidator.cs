using System;
using CustomerApp.Core.IValidators;
using CustomerApp.Core.Models;

namespace CustomerApp.Domain.Validators
{
    public class CityValidator: ICityValidator
    {
        public void DefaultValidation(City city)
        {
            if(city == null) {
                throw new NullReferenceException("City Cannot be null");
            }
            ValidateName(city);
        }

        public void ValidateName(City city)
        {
            if (string.IsNullOrEmpty(city.Name))
            {
                throw new ArgumentException("City Needs a Name");
            }
            
        }
    }
}