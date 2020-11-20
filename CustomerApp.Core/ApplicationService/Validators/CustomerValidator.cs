using System.IO;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Validators
{
    public class CustomerValidator
    {
        public void Validate(Customer customer) {
            if (customer.Address == null ||  customer.Address.Id < 1)
            {
                throw new InvalidDataException("There should always be an address");
            }

        }
    }
}