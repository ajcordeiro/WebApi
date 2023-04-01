using Entities.Models;

namespace Contracts
{
    public interface IMarcaRepository 
    {
        IEnumerable<MarcaModels> GetAllMarcas();

        MarcaModels GetMarcaById(Guid marcaId);

        MarcaModels GetMarcaWithDetails(Guid marcaId);
    }
}
