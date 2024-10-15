using CADASTRO_USUARIOS.Models;
using System.ComponentModel.DataAnnotations;

namespace CADASTRO_USUARIOS.DTOs;

public class UsuarioDTO
{
    [MaxLength(50)]
    public string? USUARIO { get; set; }

    [MaxLength(120)]
    public string? NOME { get; set; }

    [MaxLength(120)]
    public string? EMAIL { get; set; }

    [MinLength(6)]
    [MaxLength(250)]
    public string? SENHA { get; set; }

    public string NIVEL { get; set; }

    [MaxLength(50)]
    public string? CRIADOPOR { get; set; }

    public DateTime CRIADOEM { get; set; }

    [MaxLength(50)]
    public string? ALTERADOPOR { get; set; }

    public DateTime ALTERADOEM { get; set; }
}