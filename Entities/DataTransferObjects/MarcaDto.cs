using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class MarcaDto
    {
        public Guid Id { get; set; }

        public string? MarcaVeiculo { get; set; }

        public IEnumerable<ModeloDto>? Modelo { get; set; }
    }
}
