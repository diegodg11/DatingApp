using System;
using System.Linq;
using System.Threading.Tasks;
using DatingAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Data
{
    // esta la implementacion concreta del repositorio definido en la interfaz IAuthRepository
    // como hacemos disponible el reposorio para los controllers?
    // declarando el servicio en el Startup cs

    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext db;

        public AuthRepository(DataContext context)
        {
            db = context;
        }

        public async Task<Usuario> Login(string usuario, string contrasenia)
        {
            var usr = await db.Usuarios.FirstOrDefaultAsync(e => e.Username==usuario);
             if (usr==null)
             return null;

            if (!VerificarPassword(usr.PasswordSalt,usr.PasswordHash,contrasenia))
             return null;

            return usr;

        }

        private bool VerificarPassword(byte[] passwordSalt, byte[] passwordHash, string contrasenia)
        {
                 using (var hmac= new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
              var passwordHashCalculado = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasenia));
                for (int i = 0; i < passwordHashCalculado.Length; i++)
                {
                    if (passwordHashCalculado[i]!= passwordHash[i])
                    return false;
                }
                
            }

            return true;
        }

        public async Task<Usuario> Registrar(Usuario usuario, string contrasenia)
        {
            byte[] contraseniaHash,contraseniaSalt;
            
            CrearContraseniaHash(contrasenia, out contraseniaHash, out contraseniaSalt);
            
            usuario.PasswordHash= contraseniaHash;
            
            usuario.PasswordSalt= contraseniaSalt;
            
            await db.Usuarios.AddAsync(usuario);
            await db.SaveChangesAsync();
            
            return usuario;
        }

       
        private void CrearContraseniaHash(string contrasenia, out byte[] contraseniaHash, out byte[] contraseniaSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                contraseniaHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasenia) );
                contraseniaSalt= hmac.Key;
            }

        }

        public async Task<bool> VerificarExistenciaUsuario(string usuario)
        {
           var usr = await db.Usuarios.AnyAsync(e => e.Username==usuario);
           if (usr) return true;
           return false;
        }
    }
}