using CADASTRO_USUARIOS.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CADASTRO_USUARIOS.Context;

public class ContextGerenciarUSUARIOS : DbContext
{
    public ContextGerenciarUSUARIOS(DbContextOptions<ContextGerenciarUSUARIOS> options) : base(options) { }

    public DbSet<Usuario> USUARIOS { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Usuario>().HasKey(c => c.USUARIO);

        mb.Entity<Usuario>()
            .Property(u => u.USUARIO)
            .HasMaxLength(50)
            .IsRequired();

        mb.Entity<Usuario>()
            .Property(u => u.NOME)
            .HasMaxLength(120)
            .IsRequired();

        mb.Entity<Usuario>()
            .Property(u => u.EMAIL)
            .HasMaxLength(120)
            .IsRequired();

        mb.Entity<Usuario>()
            .Property(u => u.SENHA)
            .HasMaxLength(250)
            .IsRequired();

        mb.Entity<Usuario>()
            .Property(u => u.CRIADOPOR)
            .HasMaxLength(50)
            .IsRequired();

        mb.Entity<Usuario>()
            .Property(u => u.ALTERADOPOR)
            .HasMaxLength(50)
            .IsRequired();

        mb.Entity<Usuario>().HasData(
            new Usuario
            {
                USUARIO = "admin",
                NOME = "ADMIN",
                EMAIL = "email@teste.com.br",
                SENHA = "$2a$11$IlnYxBzBJncE22K4KNGHhebxVCDdsbRlKKb8ufoyYGhbEMW25mY4W", // senha: admin123
                NIVEL = "A",
                CRIADOPOR = "admin",
                CRIADOEM = DateTime.Now,
                ALTERADOPOR = "admin",
                ALTERADOEM = DateTime.Now
            }
        );
    }

}
