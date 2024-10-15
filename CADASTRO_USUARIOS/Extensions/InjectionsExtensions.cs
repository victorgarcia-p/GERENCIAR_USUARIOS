using CADASTRO_USUARIOS.Services.Interfaces;
using CADASTRO_USUARIOS.Services;
using CADASTRO_USUARIOS.Repositories.Interfaces;
using CADASTRO_USUARIOS.Repositories;

namespace CADASTRO_USUARIOS.Extensions;

public static class InjectionsExtensions
{
    public static WebApplicationBuilder ServicesInjectionsExtensions(this WebApplicationBuilder builder)
    {
        #region DB
        builder.Services.AddScoped<IServiceUsuario, ServiceUsuario>();
        #endregion

        #region Utility
        builder.Services.AddScoped<IServiceLogin, ServiceLogin>();
        builder.Services.AddScoped<IServiceUtil, ServiceUtil>();
        #endregion

        return builder;
    }

    public static WebApplicationBuilder RepositoriesInjectionsExtensions(this WebApplicationBuilder builder)
    {
        #region DB
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        #endregion

        return builder;
    }

    //public static WebApplicationBuilder MapperInjectionsExtensions(this WebApplicationBuilder builder)
    //{
    //    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    //    return builder;
    //}
}
