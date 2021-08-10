using System;
using CustomerApp.Core.IValidators;
using CustomerApp.Core.Models;

namespace CustomerApp.Domain.Validators
{
    public class AddressValidator: IAddressValidator
    {
        public void DefaultValidation(Address address)
        {
            if(address == null) {
                throw new NullReferenceException("Address Cannot be Null");
            }
        }
    }
}