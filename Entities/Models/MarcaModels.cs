using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Entities.Models
{
    [Table("marca")]
    public class MarcaModels
    {
        [Column("marcaId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A marca do veiculo é obrigatório")]
        [StringLength(11, ErrorMessage = "A marca do veiculo não pode ter mais de 11 caracteres")]
        public string? Marca { get; set; }

        public ICollection<ModeloModels>? Modelos { get; set; }

    }
}
