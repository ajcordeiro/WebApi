namespace Entities.DTOs
{
    public class ModeloDto
    {
        public Guid Id { get; set; }

        public string? Modelo { get; set; }

        public string? AnoModelo { get; set; }

        public string? AnoFabricacao { get; set; }

        public string? FabricanteId { get; set; }

        public string? CombustivelId { get; set; }

        public FabricanteDto? Fabricante { get; set; }
    }
}
