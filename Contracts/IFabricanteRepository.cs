using Entities.Models;

namespace Contracts
{
    public interface IFabricanteRepository : IRepositoryBase<FabricanteModels>
    {
        IEnumerable<FabricanteModels> GetAllFabricantes();

        FabricanteModels GetFabricanteById(Guid fabricanteId);

        FabricanteModels GetFabricanteWithDetails(Guid fabricanteId);

        void CreateFabricante(FabricanteModels fabricante);

        void UpdateFabricante(FabricanteModels fabricante);

     
    }
}
