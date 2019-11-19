using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingAppAPI.Data;
using DatingAppAPI.Dtos;
using DatingAppAPI.Models;
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
        private readonly IMapper mapper;
        public UsersController(IDatingRepository context, IMapper _mapper)
        {
            mapper = _mapper;
            repo = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var usrs = await repo.GetUsuarios();

            var usrsDto = mapper.Map<IEnumerable<UsuarioParaListaDto>>(usrs);


            return Ok(usrsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {

            var usr = await repo.GetUsuario(id);
            var usrDto = mapper.Map<UsuarioDetalleDto>(usr);

            return Ok(usrDto);
        }


    }
}