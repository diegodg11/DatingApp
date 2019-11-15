using System;
using System.Collections.Generic;

namespace DatingAppAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Genero { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Alias { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimoIngreso { get; set; }
        public string Presentacion { get; set; }
        
        public string Buscando { get; set; }
        public string Interes { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public ICollection<Foto> Fotos { get; set; }
    }
}