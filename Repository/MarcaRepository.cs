using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
    {
        public MarcaRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
            
        {
        }
    }
}
