using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class MarcaForCreationDto
    {
        [Required(ErrorMessage = "O fabricante do veiculo é obrigatório")]
        [StringLength(11, ErrorMessage = "A marca do veiculo não pode ter mais de 11 caracteres")]
        public string? MarcaVeiculo { get; set; }

        public string? veiculoId { get; set; }
    }
}
