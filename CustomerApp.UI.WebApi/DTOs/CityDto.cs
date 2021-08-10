using System.Collections.Generic;
using CustomerApp.Core.Models;

namespace CustomerApp.UI.WebApi.DTOs
{
    public class CityDto
    {
        public int ZipCode { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Tourist> Tourists { get; set; }
    }
}