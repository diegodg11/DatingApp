using System;

namespace DatingAppAPI.Dtos
{
    public class FotoDetalleUsuarioDto
    {

         public int Id { get; set; }
        public string Nombre { get; set; }

        public string Url { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaCarga { get; set; }

        public bool EsPrincipal { get; set; }


    }
        
    }
