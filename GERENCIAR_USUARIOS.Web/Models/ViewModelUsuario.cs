using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GERENCIAR_USUARIOS.Web.Models;

public class ViewModelUsuario
{
    [MaxLength(50)]
    [JsonPropertyName("USUARIO")]
    public string? USUARIO { get; set; }

    [MaxLength(120)]
    [JsonPropertyName("NOME")]
    public string? NOME { get; set; }

    [MaxLength(120)]
    [JsonPropertyName("EMAIL")]
    public string? EMAIL { get; set; }

    [MinLength(6)]
    [MaxLength(250)]
    [JsonPropertyName("SENHA")]
    public string? SENHA { get; set; }

    [JsonPropertyName("NIVEL")]
    public string? NIVEL { get; set; }

    [MaxLength(50)]
    [JsonPropertyName("CRIADOPOR")]
    public string? CRIADOPOR { get; set; }

    [JsonPropertyName("CRIADOEM")]
    public DateTime CRIADOEM { get; set; }

    [MaxLength(50)]
    [JsonPropertyName("ALTERADOPOR")]
    public string? ALTERADOPOR { get; set; }

    [JsonPropertyName("ALTERADOEM")]
    public DateTime ALTERADOEM { get; set; }
}
