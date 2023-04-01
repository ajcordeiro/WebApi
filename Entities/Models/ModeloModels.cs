using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("modelo")]
    public class ModeloModels
    {
        [Column("modeloId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O modelo do veiculo é obrigatório")]
        [StringLength(11, ErrorMessage = "O modelo do veiculo não pode ter mais de 11 caracteres")]
        public string? Modelo { get; set; }

        [ForeignKey(nameof(MarcaModels))]
        public Guid MarcaId { get; set; }
        public MarcaModels? Marca { get; set; }

    }
}
