using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IMarcaRepository _marca;
        private IModeloRepository _modelo;

        public IMarcaRepository Marca
        {
            get
            {
                if (_marca == null)
                {
                    _marca = new MarcaRepository(_repoContext);
                }
                return _marca;
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
            throw new NotImplementedException();
        }
    }
}
