using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ModeloForCreationDto
    {
        [Required(ErrorMessage = "O fabricante do veiculo é obrigatório")]
        [StringLength(11, ErrorMessage = "A marca do veiculo não pode ter mais de 11 caracteres")]
        public string? Modelo { get; set; }

        public string? AnoModelo { get; set; }

        public string? AnoFabricacao { get; set; }

        public Guid FabricanteId { get; set; }

        public Guid CombustivelId { get; set; }
    }
}
