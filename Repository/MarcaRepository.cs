using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class MarcaRepository : RepositoryBase<MarcaModels>, IMarcaRepository
    {
        public MarcaRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }

        public IEnumerable<MarcaModels> GetAllMarcas()
        {
            return FindAll()
                .OrderBy(ow => ow.Marca)
                .ToList();
        }

        public MarcaModels GetMarcaById(Guid marcaId)
        {
            return FindByCondition(marca => marca.Id.Equals(marcaId))
           .FirstOrDefault();
        }

        public MarcaModels GetMarcaWithDetails(Guid marcaId)
        {
            return FindByCondition(marca => marca.Id.Equals(marcaId))
               .Include(ac => ac.Marca)
               .FirstOrDefault();
        }
    }
}
