using minimal_api.Dominio.DTOs;
using minimal_api.DTOs;

namespace minimal_api.Dominio.Servicos
{
    public interface IAdministradorService
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}