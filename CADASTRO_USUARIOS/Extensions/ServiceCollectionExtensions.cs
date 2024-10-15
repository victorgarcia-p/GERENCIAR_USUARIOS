using CADASTRO_USUARIOS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CADASTRO_USUARIOS.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddApiSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    public static WebApplicationBuilder ConnectionStringPersistence(this WebApplicationBuilder builder)
    {
        var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<ContextGerenciarUSUARIOS>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

        return builder;
    }
}
