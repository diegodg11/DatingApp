using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Controllers
{
    //esto attribuite routing
    //http://localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize] 
    public class ValuesController : ControllerBase
    {
        private readonly DataContext db;
        public ValuesController(DataContext context)
        {
            db = context;
        }

        //values es el nombre del controller http://localhost:5000/api/values devuelve el metodo get por defecto
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "valor1", "valor2" };
        }
       
        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetValues (){

            var valores = db.Valores.ToList();

            return Ok(valores);
        }

        [HttpGet("asyncall")]
         [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync() {

        var valores = await db.Valores.ToListAsync();
        return Ok(valores);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<string> Get(int id)
        {
            return "valor con id en url " + id;
        }
        [HttpGet("id/{id}")]
        public IActionResult GetValor(int id)
        {
            var valor = db.Valores.FirstOrDefault(e => e.Id==id);
            return Ok(valor);
        }
        
         [HttpGet("idasyn/{id}")]
        public async Task<IActionResult> GetV (int id) {

            var valor = await db.Valores.FirstOrDefaultAsync(x => x.Id==id);
            return Ok(valor);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
