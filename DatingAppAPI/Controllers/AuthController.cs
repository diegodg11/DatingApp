using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingAppAPI.Data;
using DatingAppAPI.Dtos;
using DatingAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //apicontroller nos permite validar contra las dataannotations de los dtos
    //e infiere el tipo de datos que estamos pasando desde el jsonobject al metodo
    // sin apicontroller deberiamos usar [FromBody] para obtener el objeto
    // y ModelState para validar contra  las dataannotations
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repo;
        private readonly IConfiguration config;
        public AuthController(IAuthRepository context, IConfiguration iconfig)
        {
            config = iconfig;
            repo = context;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioARegistrar usr)
        {
            //primero deberiamos validar el request

            usr.Usuario = usr.Usuario.ToLower();

            if (await repo.VerificarExistenciaUsuario(usr.Usuario))
                return BadRequest("El usuario ya existe.");

            var usuarioACrear = new Usuario()
            {
                Username = usr.Usuario
            };

            var usuarioCreado = await repo.Registrar(usuarioACrear, usr.Password);
            return StatusCode(201);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginDto usrDto)
        {

            var usr = await repo.Login(usrDto.Usuario.ToLower(), usrDto.Contrasenia);

            if (usr == null)
                return Unauthorized();
        //primero creamos los componentes del token
        //los claims
            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier,usr.Id.ToString()),
            new Claim(ClaimTypes.Name, usr.Username)
            };

// dps la key que definimos en el appsetting.json
            string s =config.GetSection("AppSettings:Token").Value;
            var clave = new SymmetricSecurityKey(Encoding.UTF8.
            GetBytes(config.GetSection("AppSettings:Token").Value));
// con la clave creamos las credenciales
            var credenciales = new SigningCredentials(clave,SecurityAlgorithms.HmacSha512Signature);
//la descripcion del token con los claims, fecha vto y credenciales
            var tokenDescriptor = new SecurityTokenDescriptor(){
                Subject= new ClaimsIdentity(claims),
                Expires= System.DateTime.Now.AddDays(1),
                SigningCredentials= credenciales
            };
// dps necesitamos un handler para crear el token usando el descriptor
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
//devolvemos el token con el formato adecuado
            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }

    }
}