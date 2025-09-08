using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;
using minimal_api.DTOs;

namespace minimal_api.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Email = "Adm@teste.com",
                    Senha = "123456",
                    Perfil = "Adm"
                });
        }

        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {
        }

        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Veiculo> Veiculos { get; set; } = default!;
    }
}