namespace InnoTech.CustomerApp.Infrastructure.SQL.DBEntities
{
    public class CustomerSql
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // CRUD
        public int AddressId { get; set; }
        //R
        public AddressSql Address { get; set; }
    }
}