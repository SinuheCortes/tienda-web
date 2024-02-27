using Microsoft.AspNetCore.Mvc;
using Store.Api.Bussiness;
using Store.Api.Dtos;
using Store.Api.Entitys;


namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprarArticulosController : ControllerBase
    {
        private readonly ClienteBussiness _negocio;
        public ComprarArticulosController()
        {
            _negocio = new ClienteBussiness();
        }
        [HttpPost]
        public IActionResult Post([FromBody] ClienteArticuloDto[] clienteArticulo)
        {
            if (clienteArticulo.Length < 1)
            {
                return BadRequest();
            }
            bool respuesta = _negocio.ComprarArticulos(clienteArticulo);
            return respuesta ? NoContent() : StatusCode(500);
        }
    }
}
