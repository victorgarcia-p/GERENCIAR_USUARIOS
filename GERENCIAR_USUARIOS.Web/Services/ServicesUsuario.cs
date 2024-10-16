using GERENCIAR_USUARIOS.Web.Models;
using GERENCIAR_USUARIOS.Web.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace GERENCIAR_USUARIOS.Web.Services;

public class ServicesUsuario : IServicesUsuario
{
    private readonly IHttpClientFactory _ClientFactory;
    private const string apiUser = "/api/Usuarios/";
    private readonly JsonSerializerOptions _serializerOptions;
    private ViewModelUsuario userVM;
    private IEnumerable<ViewModelUsuario> usersVM;

    public ServicesUsuario(IHttpClientFactory clientFactory)
    {
        _ClientFactory = clientFactory;
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<ViewModelUsuario>> GetAll()
    {
        var client = _ClientFactory.CreateClient("usersAPI");

        using (var response = await client.GetAsync(apiUser))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                usersVM = await JsonSerializer.DeserializeAsync<IEnumerable<ViewModelUsuario>>(apiResponse, _serializerOptions);
            }
            else
            {
                return null;
            }
        }
        return usersVM;
    }

    public async Task<ViewModelUsuario> Get(string USUARIO)
    {
        var client = _ClientFactory.CreateClient("usersAPI");

        using (var response = await client.GetAsync(apiUser + USUARIO))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                userVM = await JsonSerializer.DeserializeAsync<ViewModelUsuario>(apiResponse, _serializerOptions);
            }
            else
            {
                return null;
            }
        }
        return userVM;
    }

    public async Task<ViewModelUsuario> Create(ViewModelUsuario USUARIO)
    {
        var client = _ClientFactory.CreateClient("usersAPI");

        StringContent content = new StringContent(JsonSerializer.Serialize(USUARIO), Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiUser, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                userVM = await JsonSerializer.DeserializeAsync<ViewModelUsuario>(apiResponse, _serializerOptions);
            }
            else
            {
                return null;
            }
        }
        return userVM;
    }

    public async Task<ViewModelUsuario> Update(ViewModelUsuario USUARIO)
    {
        var client = _ClientFactory.CreateClient("usersAPI");

        ViewModelUsuario usuarioAlterado = new ViewModelUsuario();

        using (var response = await client.PutAsJsonAsync(apiUser, USUARIO))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                usuarioAlterado = await JsonSerializer.DeserializeAsync<ViewModelUsuario>(apiResponse, _serializerOptions);
            }
            else
            {
                return null;
            }
        }
        return usuarioAlterado;
    }

    public async Task<ViewModelUsuario> UpdateSenha(ViewModelUsuario USUARIO)
    {
        var client = _ClientFactory.CreateClient("usersAPI");

        ViewModelUsuario usuarioAlterado = new ViewModelUsuario();

        using (var response = await client.PutAsJsonAsync(apiUser, USUARIO))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                usuarioAlterado = await JsonSerializer.DeserializeAsync<ViewModelUsuario>(apiResponse, _serializerOptions);
            }
            else
            {
                return null;
            }
        }
        return usuarioAlterado;
    }

    public async Task<string> Delete(string USUARIO)
    {
        var client = _ClientFactory.CreateClient("usersAPI");
        var retorno = "";
        using (var response = await client.DeleteAsync(apiUser + USUARIO))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                retorno = await JsonSerializer.DeserializeAsync<string>(apiResponse, _serializerOptions);
            }
            else
            {
                return null;
            }
        }
        return retorno;
    }

}
