namespace CustomerApp.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // CRUD
        public int AddressId { get; set; }
        //R
        public Address Address { get; set; }
    }
}
