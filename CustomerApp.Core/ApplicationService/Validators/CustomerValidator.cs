using System.IO;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Validators
{
    public class CustomerValidator
    {
        public void Validate(Customer customer) {
            if (customer.Address == null)
            {
                throw new InvalidDataException("Address Length Must be above 1 letter");
            }

        }
    }
}