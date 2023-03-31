using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IVeiculoRepository _veiculo;
        private IMarcaRepository _marca;

        public IVeiculoRepository Veiculo
        {
            get
            {
                if (_veiculo == null)
                {
                    _veiculo = new VeiculoRepository(_repoContext);
                }
                return _veiculo;
            }
        }

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
