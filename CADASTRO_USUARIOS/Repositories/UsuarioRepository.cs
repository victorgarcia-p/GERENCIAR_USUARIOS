using CADASTRO_USUARIOS.Context;
using CADASTRO_USUARIOS.Models;
using CADASTRO_USUARIOS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CADASTRO_USUARIOS.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ContextGerenciarUSUARIOS _context;

    public UsuarioRepository(ContextGerenciarUSUARIOS context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAll()
    {
        return await _context.USUARIOS.ToListAsync();
    }

    public async Task<Usuario> Get(string USUARIO)
    {
        return await _context.USUARIOS.FirstOrDefaultAsync(x => x.USUARIO == USUARIO);
    }

    public async Task<Usuario> Create(Usuario USUARIO)
    {
        _context.USUARIOS.Add(USUARIO);
        await _context.SaveChangesAsync();
        return USUARIO;
    }

    public async Task<Usuario> Update(Usuario USUARIO)
    {
        _context.Entry(USUARIO).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return USUARIO;
    }

    public async Task<string> Delete(string USUARIO)
    {
        try
        {
            var UsuarioBanco = await Get(USUARIO);
            _context.USUARIOS.Remove(UsuarioBanco);
            return $"Usuário: {USUARIO} - Removido com Sucesso";
        }
        catch (Exception ex)
        {
            var mensagem = ex.InnerException is null ? ex.Message : ex.InnerException.Message;
            return $"Erro ao remover o Usuário: {USUARIO} - {mensagem}";
        }


    }
}
