using System.IO;
using CustomerApp.Core.Models;

namespace CustomerApp.Core.Domain.Validators
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