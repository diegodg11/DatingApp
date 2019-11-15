using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext db;

        public DatingRepository(DataContext context)
        {
            db = context;
        }
        public void Add<E>(E entidad) where E : class
        {
            db.Add(entidad);
        }

        public void Remove<E>(E entidad) where E : class
        {
           db.Remove(entidad);
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            //fotos es una navegation property, si queremos traerla debemos incluirla
          return await db.Usuarios.Include(p=> p.Fotos).Where(e=> e.Id==id).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await db.Usuarios.Include(e=> e.Fotos).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
          return  await db.SaveChangesAsync()>0;
        }
    }
}