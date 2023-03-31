using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("marca")]
    public class Marca
    {
        [Column("MarcaId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A marca do veiculo é obrigatório")]
        [StringLength(11, ErrorMessage = "A marca do veiculo não pode ter mais de 11 caracteres")]
        public string? MarcaVeiculo { get; set; }

        [ForeignKey(nameof(Veiculo))]
        public Guid VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }

    }
}
