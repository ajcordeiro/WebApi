﻿using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ModeloRepository : RepositoryBase<ModeloModels>, IModeloRepository
    {
        public ModeloRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
            
        {
        }

        public void CreateModelo(ModeloModels modelo)
        {
            Create(modelo);
        }

        public IEnumerable<ModeloModels> GetAllModelos()
        {
            return FindAll()
              .OrderBy(ow => ow.Id)
              .ToList();
        }

        public ModeloModels GetModeloById(Guid modeloId)
        {
            return FindByCondition(modelo => modelo.Id.Equals(modeloId))
                    .FirstOrDefault();
        }

        public ModeloModels GetModeloWithDetails(Guid Id)
        {
            return FindByCondition(owner => owner.Id.Equals(Id))
            .FirstOrDefault();
        }
    }
}
