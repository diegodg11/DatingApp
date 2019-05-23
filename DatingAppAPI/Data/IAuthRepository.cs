using System.Threading.Tasks;
using DatingAppAPI.Models;

namespace DatingAppAPI.Data
{
    public interface IAuthRepository
    {
        
        Task<Usuario> Registrar(Usuario usuario, string contrasenia);
        
        Task<Usuario> Login(string usuario, string contrasenia);

        Task<bool> VerificarExistenciaUsuario(string usuario);

    }
}