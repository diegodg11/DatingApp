using System;

namespace DatingAppAPI.Dtos
{
    public class UsuarioParaListaDto
    {
        
        public int Id { get; set; }
        public string Username { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Alias { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimoIngreso { get; set; }

        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string UrlFotoPrincipal { get; set; }
    }
}