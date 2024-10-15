namespace CADASTRO_USUARIOS.Services.Interfaces;

public interface IServiceUtil
{
    string CryptSenha(string senha);

    bool VerificarSenha(string senha, string senhaCriptografada);
}
