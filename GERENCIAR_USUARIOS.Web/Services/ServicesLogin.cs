using GERENCIAR_USUARIOS.Web.Models;
using GERENCIAR_USUARIOS.Web.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace GERENCIAR_USUARIOS.Web.Services;

public class ServicesLogin : IServicesLogin
{
    private readonly IHttpClientFactory _ClientFactory;
    private const string apiUser = "/api/Login/";
    private readonly JsonSerializerOptions _serializerOptions;
    private ViewModelUsuario userVM;

    public ServicesLogin(IHttpClientFactory clientFactory)
    {
        _ClientFactory = clientFactory;
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<ViewModelUsuario> Post(ViewModelRequestLogin login)
    {
        var client = _ClientFactory.CreateClient("usersAPI");

        StringContent content = new StringContent(JsonSerializer.Serialize(login), Encoding.UTF8, "application/json");

        try
        {
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
        catch(Exception ex)
        {
            throw;
        }
        
    }
}
