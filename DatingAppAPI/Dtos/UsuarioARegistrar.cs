using System.ComponentModel.DataAnnotations;

namespace DatingAppAPI.Dtos
{
    //las data annotations conviene aplicarselas a los dtos para las validaciones desde la api
    public class UsuarioARegistrar
    {
        [Required(ErrorMessage="El nombre de usuario es requerido.")]
        public string Usuario { get; set; }
        
        [Required(ErrorMessage="El password es requerido.")]
        [StringLength(12,MinimumLength=8,ErrorMessage="El password debe contener entre 8 y 12 caracteres.")]
       public string Password { get; set; }
    }
}