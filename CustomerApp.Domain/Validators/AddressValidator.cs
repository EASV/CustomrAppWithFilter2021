using System;
using CustomerApp.Core.IValidators;
using CustomerApp.Core.Models;

namespace CustomerApp.Core.Domain.Validators
{
    public class AddressValidator: IAddressValidator
    {
        public void DefaultValidation(Address address)
        {
            if(address == null) {
                throw new NullReferenceException("Address Cannot be Null");
            }
            if(address.Id < 1) {
                throw new NullReferenceException("Address Id Cannot be less then 1");
            }
        }
    }
}