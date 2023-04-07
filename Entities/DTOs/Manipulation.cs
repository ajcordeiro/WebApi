using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class Manipulation
    {
        [Required(ErrorMessage = "O modelo do veiculo é obrigatório")]
        [StringLength(11, ErrorMessage = "O modelo do veiculo não pode ter mais de 11 caracteres")]
        public string? Modelo { get; set; }

        [Required(ErrorMessage = "O ano do modelo do veiculo é obrigatório")]
        public int? AnoModelo { get; set; }

        [Required(ErrorMessage = "O ano da fabricação do veiculo é obrigatório")]
        public int? AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O Id do fabricante do veiculo é obrigatório")]
        public Guid FabricanteId { get; set; }

        [Required(ErrorMessage = "O Id do tipo de combustível do veiculo é obrigatório")]
        public Guid CombustivelId { get; set; }
    }
}
