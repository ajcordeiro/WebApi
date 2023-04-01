using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Repository
{
    public class ModeloRepository : RepositoryBase<ModeloModels>, IModeloRepository
    {
        public ModeloRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
            
        {
        }

        public IEnumerable<ModeloModels> GetAllModelos()
        {
            return FindAll()
               .OrderBy(ow => ow.Modelo)
               .ToList();
        }
    }
}
