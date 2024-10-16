using System.Text.Json.Serialization;

namespace GERENCIAR_USUARIOS.Web.Models;

public class ViewModelRequestLogin
{
    public string Usuario { get; set; }

    public string Senha { get; set; }
}
