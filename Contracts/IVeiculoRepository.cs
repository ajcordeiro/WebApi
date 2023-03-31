using Entities.Models;

namespace Contracts
{
    public interface IVeiculoRepository : IRepositoryBase<Veiculo>
    {
        IEnumerable<Veiculo> GetAllOwners();
    }
}
