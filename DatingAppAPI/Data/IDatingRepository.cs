using System.Collections.Generic;
using System.Threading.Tasks;
using DatingAppAPI.Models;

namespace DatingAppAPI.Data
{
    public interface IDatingRepository
    {
        //segun el curso no es necesario usar async en void porque no realizamos una operacion 
        // en bd
        void Add<E>(E entidad) where E:class;
        void Remove<E>(E entidad) where E:class;

        Task<bool> SaveAll();

        Task<IEnumerable<Usuario>> GetUsuarios();

        Task<Usuario> GetUsuario(int id);

    }
}