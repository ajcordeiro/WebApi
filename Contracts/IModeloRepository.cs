using Entities.Models;

namespace Contracts
{
    public interface IModeloRepository : IRepositoryBase<ModeloModels>
    {
        IEnumerable<ModeloModels> GetAllModelos();

        ModeloModels GetModeloById(Guid modeloId);

        ModeloModels GetModeloWithDetails(Guid modeloId);

        void CreateModelo(ModeloModels modelo);
    }
}
