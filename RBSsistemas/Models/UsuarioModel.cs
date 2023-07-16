using System.Text.Json;
using System.Text.Json.Serialization;

namespace RBSsistemas.Models
{
    public class UsuarioModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}
