using System.Collections.Generic;
using DatingAppAPI.Models;
using Newtonsoft.Json;

namespace DatingAppAPI.Data
{
    public class SeedData
    {
        private readonly DataContext db;

        public SeedData(DataContext context)
        {
            db = context;

        }

        public async void SeedingUsers()
        {

            var lst = System.IO.File.ReadAllText("Data/DataSeed.json");

            List<Usuario> lstUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(lst);

            foreach (var usr in lstUsuarios)
            {
                byte[] contraseniaHash, contraseniaSalt;
                CrearContraseniaHash("password", out contraseniaHash, out contraseniaSalt);

                usr.PasswordHash = contraseniaHash;
                usr.PasswordSalt = contraseniaSalt;

                await db.Usuarios.AddAsync(usr);

            }
            await db.SaveChangesAsync();
        }



        private void CrearContraseniaHash(string contrasenia, out byte[] contraseniaHash, out byte[] contraseniaSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                contraseniaHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasenia) );
                contraseniaSalt= hmac.Key;
            }

        }


    }
}