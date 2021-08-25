using System;
using InnoTech.CustomerApp.Core.IValidators;
using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Domain.Validators
{
    public class AddressValidator: IAddressValidator
    {
        public void DefaultValidation(Address address)
        {
            if(address == null) {
                throw new NullReferenceException("Address Cannot be Null");
            }

            if (address.Id <= 0)
            {
                throw new NullReferenceException("Address Id Cannot be less then 1");
            }

            if (address.StreetName.Length <= 2)
            {
                throw new ArgumentException("Address StreetName Cannot be less then 2 characters");
            }
        }
    }
}