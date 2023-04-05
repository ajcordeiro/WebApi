using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("fabricante")]
    public class FabricanteModels
    {
        [Column("fabricanteId")]
        public Guid Id { get; set; }

        [Column("nomefabricante")]
        [Required(ErrorMessage = "O fabricante do veiculo é obrigatório")]
        [StringLength(11, ErrorMessage = "O fabricante do veiculo não pode ter mais de 11 caracteres")]
        public string? Fabricante { get; set; }
    }
}
