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
        }
    }
}