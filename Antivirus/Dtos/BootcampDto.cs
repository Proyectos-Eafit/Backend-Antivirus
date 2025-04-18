using System.Text.Json.Serialization;

namespace Antivirus.Models.DTOs
{
    public class BootcampDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public long? IdCostosId { get; set; }
        public long? IdEstadoId { get; set; }
        public long? IdGeneralId { get; set; }
        public long? IdTemasId { get; set; }
        [JsonPropertyName("informacion")]
        public string? Informacion { get; set; }
        public char? Trial751 { get; set; }
    }
    public class BootcampCreateDto
    {
        public string Nombre { get; set; } = null!;
        public long? IdCostosId { get; set; }
        public long? IdEstadoId { get; set; }
        public long? IdGeneralId { get; set; }
        public long? IdTemasId { get; set; }
        [JsonPropertyName("informacion")]

        public string? Informacion { get; set; }
        public char? Trial751 { get; set; }
    }
}