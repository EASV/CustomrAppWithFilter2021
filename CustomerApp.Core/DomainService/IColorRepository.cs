using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface IColorRepository
    {
        public Color Create(Color color);
    }
}