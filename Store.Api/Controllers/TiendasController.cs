using Microsoft.AspNetCore.Mvc;
using Store.Api.Bussiness;
using Store.Api.Entitys;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : ControllerBase
    {
        private readonly TiendaBussiness _negocio;
        public TiendasController()
        {
            _negocio = new TiendaBussiness();
        }
        [HttpGet]
        public IActionResult Obtener()
        {
            return Ok(_negocio.ObtenerTodo());
        }

        // POST api/<TiendasController>
        [HttpPost]
        public IActionResult Guardar([FromBody] Tienda tienda)
        {
            bool respuesta = _negocio.Guardar(tienda);

            return respuesta ? Ok(tienda) : StatusCode(500);
        }

        // PUT api/<TiendasController>/5
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] Tienda tienda)
        {
            if (tienda.Id != id)
            {
                return BadRequest();
            }
            bool respuesta = _negocio.Actualizar(id, tienda);
            return respuesta ? Ok() : StatusCode(500);
        }

        // DELETE api/<TiendasController>/5
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            bool respuesta = _negocio.Eliminar(id);
            return respuesta ? Ok() : StatusCode(500);
        }
    }
}
