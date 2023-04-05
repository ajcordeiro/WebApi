using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class FabricanteRepository : RepositoryBase<FabricanteModels>, IFabricanteRepository
    {
        public FabricanteRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateFabricante(FabricanteModels fabricante)
        {
            Create(fabricante);
        }

        public IEnumerable<FabricanteModels> GetAllFabricantes()
        {
            return FindAll()
                .OrderBy(ow => ow.Id)
                .ToList();
        }

        public FabricanteModels GetFabricanteById(Guid fabricanteId)
        {
            return FindByCondition(fabricante => fabricante.Id.Equals(fabricanteId))
                    .FirstOrDefault();
        }

        public FabricanteModels GetFabricanteWithDetails(Guid fabricanteId)
        {
            return FindByCondition(fabricante => fabricante.Id.Equals(fabricanteId))
                    .Include(ac => ac.Id)
                    .FirstOrDefault();
        }
    }
}
