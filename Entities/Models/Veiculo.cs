using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("veiculo")]
    public class Veiculo
    {
        [Column("VeiculoId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Tipo de veiculo é obrigatório")]
        [StringLength(11, ErrorMessage = "O Tipo de veiculo não pode ter mais de 11 caracteres")]
        public string? TipoVeiculo { get; set; }

       // public ICollection<Marca>? Marcas { get; set; }

    }
}
