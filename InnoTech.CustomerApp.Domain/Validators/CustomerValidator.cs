using System.IO;
using InnoTech.CustomerApp.Core.Models;

namespace InnoTech.CustomerApp.Domain.Validators
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