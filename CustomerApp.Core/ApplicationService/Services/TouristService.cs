using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class TouristService: ITouristService
    {
        private ITouristRepository _touristRepository;

        public TouristService(ITouristRepository touristRepository)
        {
            _touristRepository = touristRepository;
        }
        
        public List<Tourist> ReadAll()
        {
            return _touristRepository.GetAll();
        }
    }
}