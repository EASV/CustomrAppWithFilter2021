using System.Drawing;
using System.Security.Cryptography;

namespace CustomerApp.Core.Entity
{
    public class Hat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HatType HatType { get; set; }
        public Color Color { get; set; }
        public Brand Brand { get; set; }
    }

}