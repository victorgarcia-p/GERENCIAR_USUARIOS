using CADASTRO_USUARIOS.Services.Interfaces;

namespace CADASTRO_USUARIOS.Services;

public class ServiceUtil : IServiceUtil
{
    public string CryptSenha(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    public bool VerificarSenha(string senha, string senhaCriptografada)
    {
        return BCrypt.Net.BCrypt.Verify(senha, senhaCriptografada);
    }
}
