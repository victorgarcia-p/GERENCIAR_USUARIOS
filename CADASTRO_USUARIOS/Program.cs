using CADASTRO_USUARIOS.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddApiSwagger();
builder.Services.AddCors();
builder.ConnectionStringPersistence();
builder.ServicesInjectionsExtensions();
builder.RepositoriesInjectionsExtensions();
builder.MapperInjectionsExtensions();

var app = builder.Build();

var environment = app.Environment;

app.UseExceptionHandling(environment);
app.UseSwaggerMiddleware();
app.UseAppCors();

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();
