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

        [Required(ErrorMessage = "O ano do modelo do veiculo é obrigatório")]
        public int? AnoModelo { get; set; }

        [Required(ErrorMessage = "O ano da fabricação do veiculo é obrigatório")]
        public int? AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O Id do fabricante do veiculo é obrigatório")]
        public Guid FabricanteId { get; set; }

        [Required(ErrorMessage = "O Id do tipo de combustível do veiculo é obrigatório")]
        public Guid CombustivelId { get; set; }

        [ForeignKey(nameof(FabricanteModels))]
        public Guid fabricanteId { get; set; }
        public FabricanteModels? fabricante { get; set; }

    }
}
