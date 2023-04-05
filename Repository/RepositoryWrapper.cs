using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IFabricanteRepository _fabricante;
        private IModeloRepository _modelo;

        public IFabricanteRepository Fabricante
        {
            get
            {
                if (_fabricante == null)
                {
                    _fabricante = new FabricanteRepository(_repoContext);
                }
                return _fabricante;
            }
        }

        public IModeloRepository Modelo
        {
            get
            {
                if (_modelo == null)
                {
                    _modelo = new ModeloRepository(_repoContext);
                }
                return _modelo;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
