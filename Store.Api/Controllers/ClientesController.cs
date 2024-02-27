using Microsoft.AspNetCore.Mvc;
using Store.Api.Bussiness;
using Store.Api.Entitys;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteBussiness _negocio;
        public ClientesController()
        {
            _negocio = new ClienteBussiness();
        }
        [HttpGet]
        public IActionResult Obtener()
        {
            return Ok(_negocio.ObtenerTodo());
        }

        [HttpGet("{id}")]
        public IActionResult Obtener(Guid id)
        {
            return Ok(_negocio.ObtenerUnico(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            bool resultado = _negocio.Guardar(cliente);

            return resultado ? NoContent() : BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(Guid id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            bool respuesta = _negocio.Actualizar(id, cliente);
            return respuesta ? NoContent() : BadRequest();
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
