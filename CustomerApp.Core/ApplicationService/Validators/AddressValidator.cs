using System;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Validators
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