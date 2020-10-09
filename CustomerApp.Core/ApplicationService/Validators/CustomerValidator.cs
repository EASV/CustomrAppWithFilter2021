using System.IO;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Validators
{
    public class CustomerValidator
    {
        public void Validate(Customer customer) {
            if (customer.AddressId < 1)
            {
                throw new InvalidDataException("There should alwys be an");
            }

        }
    }
}