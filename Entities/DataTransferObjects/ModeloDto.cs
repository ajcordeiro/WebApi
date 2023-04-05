namespace Entities.DataTransferObjects
{
    public class ModeloDto
    {
        public Guid Id { get; set; }

        public string? Modelo { get; set; }

        public IEnumerable<MarcaDto>? fabricante { get; set; }
    }
}
