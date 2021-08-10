using System.Collections.Generic;
using CustomerApp.Core.Models;

namespace CustomerApp.Core.IServices
{
    public interface ICountryService
    {
        List<Country> ReadAll();
    }
}