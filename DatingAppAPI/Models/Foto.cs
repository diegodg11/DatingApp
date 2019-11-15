using System;

namespace DatingAppAPI.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Url { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaCarga { get; set; }

        public bool EsPrincipal { get; set; }

        //la convencion dice que si agrego esta relacion
        //conjunto a la coleccion de fotos en la clase usuario
        //se genera una relacion con cascade delete
        public Usuario Usuario { get; set; }
        public int usuarioID { get; set; }
    }
}