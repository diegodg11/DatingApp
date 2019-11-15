using System.Threading.Tasks;
using DatingAppAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DatingAppAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //apicontroller nos permite validar contra las dataannotations de los dtos
    //e infiere el tipo de datos que estamos pasando desde el jsonobject al metodo
    // sin apicontroller deberiamos usar [FromBody] para obtener el objeto
    // y ModelState para validar contra  las dataannotations
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository repo;

        public UsersController(IDatingRepository context)
        {
            repo = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(){
            
            var usrs = await repo.GetUsuarios();
            
            return Ok(usrs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id){

             var usr = await repo.GetUsuario(id);   
            return Ok(usr);
        }


    }
}