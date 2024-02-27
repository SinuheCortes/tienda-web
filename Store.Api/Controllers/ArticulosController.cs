using Microsoft.AspNetCore.Mvc;
using Store.Api.Bussiness;
using Store.Api.Dtos;
using Store.Api.Entitys;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ArticuloBussiness _negocio;
        public ArticulosController()
        {
            _negocio = new ArticuloBussiness();
        }
        [HttpGet("{idTienda}")]
        public IActionResult ObtenerTodo(int idTienda)
        {
            return Ok(_negocio.ObtenerTodo(idTienda));
        }

        [HttpPost]
        public IActionResult Guardar([FromBody] ArticuloDto articulo)
        {
            bool respuesta = _negocio.Guardar(articulo);
            return respuesta ? NoContent() : StatusCode(500);
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(Guid id, [FromBody] ArticuloDto articulo)
        {
            if (id != articulo.Codigo)
            {
                return BadRequest();
            }
            bool respuesta = _negocio.Actualizar(articulo);

            return respuesta ? NoContent() : StatusCode(500);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (Guid.Empty == id)
            {
                return BadRequest();
            }
            bool respuesta = _negocio.Eliminar(id);

            return respuesta ? NoContent() : StatusCode(500);
        }
    }
}
