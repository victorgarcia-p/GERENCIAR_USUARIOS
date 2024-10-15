

using System.Text.Json.Serialization;

namespace CADASTRO_USUARIOS.Models;

public class Usuario
{
    [JsonPropertyName("USUARIO")]
    public string? USUARIO { get; set; }

    [JsonPropertyName("NOME")]
    public string? NOME { get; set; }

    [JsonPropertyName("EMAIL")]
    public string? EMAIL {  get; set; }

    [JsonPropertyName("SENHA")]
    public string? SENHA { get; set; }

    [JsonPropertyName("NIVEL")]
    public string? NIVEL { get; set; }

    [JsonPropertyName("CRIADOPOR")]
    public string? CRIADOPOR { get; set; }

    [JsonPropertyName("CRIADOEM")]
    public DateTime CRIADOEM { get; set; }

    [JsonPropertyName("ALTERADOPOR")]
    public string? ALTERADOPOR { get; set; }

    [JsonPropertyName("ALTERADOEM")]
    public DateTime ALTERADOEM { get; set; }
}
