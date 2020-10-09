using System.Drawing;
using System.Security.Cryptography;

namespace CustomerApp.Core.Entity
{
    public class Hat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HatTypeId { get; set; }
        public HatType HatType { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }

}