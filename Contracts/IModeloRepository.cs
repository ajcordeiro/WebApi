using Entities.Models;

namespace Contracts
{
    public interface IModeloRepository 
    {
       // IEnumerable<ModeloModels> GetAllModelos();
        IEnumerable<ModeloModels> GetAllModelos();

       // ModeloModels GetModeloById(Guid modeloId);

       // ModeloModels GetModeloWithDetails(Guid modeloId);
    }
}
