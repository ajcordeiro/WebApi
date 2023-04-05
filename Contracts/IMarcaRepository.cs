using Entities.Models;

namespace Contracts
{
    public interface IMarcaRepository : IRepositoryBase<MarcaModels>
    {
        IEnumerable<MarcaModels> GetAllMarcas();

        MarcaModels GetMarcaById(Guid marcaId);

        MarcaModels GetMarcaWithDetails(Guid marcaId);

        void CreateMarca(MarcaModels marca);
    }
}
