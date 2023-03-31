using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class VeiculoRepository : RepositoryBase<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
        public IEnumerable<Veiculo> GetAllOwners()
        {
            return FindAll()
                .OrderBy(ow => ow.TipoVeiculo)
                .ToList();
        }
    }
}
