using System;
using System.Collections.Generic;
using DatingAppAPI.Models;

namespace DatingAppAPI.Dtos
{
    public class UsuarioDetalleDto
    {
      
        public int Id { get; set; }
        public string Username { get; set; }

        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Alias { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimoIngreso { get; set; }
        public string Presentacion { get; set; }
        
        public string Buscando { get; set; }
        public string Interes { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public ICollection<FotoDetalleUsuarioDto> Fotos { get; set; }  

        public string URLFotoPrincipal { get; set; }
    }
}