﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IFabricanteRepository Fabricante { get; }

        IModeloRepository Modelo { get; }

        void Save();
    }
}
