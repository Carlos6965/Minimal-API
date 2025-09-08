using minimal_api.Dominio.DTOs;
using minimal_api.DTOs;
using minimal_api.Infraestrutura.Db;

namespace minimal_api.Dominio.Servicos
{
    public class AdministradorService : IAdministradorService
    {
        private readonly DbContexto _contexto;
        public AdministradorService(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores
                .Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha)
                .FirstOrDefault();
            return adm;
        }
    }
}