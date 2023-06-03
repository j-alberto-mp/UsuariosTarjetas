using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Usuarios.Core.Contratos.Factories;
using Usuarios.Core.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Usuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IServiceFactory servicio;

        public ClienteController(IServiceFactory servicio)
        {
            this.servicio = servicio;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await servicio.ServicioCliente.ObtenerListaAsync();

            if (resultado.Correcto)
            {
                return Ok(resultado.Datos);
            }
            else
            {
                return BadRequest(resultado.Mensaje);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resultado = await servicio.ServicioCliente.ObtenerPorIdAsync(id);

            if (resultado.Correcto)
            {
                return Ok(resultado.Datos);
            }
            else
            {
                return BadRequest(resultado.Mensaje);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post(ClienteDto model)
        {
            var resultado = await servicio.ServicioCliente.CrearAsync(model);

            if (resultado.Correcto)
            {
                return Ok(resultado.Datos);
            }
            else
            {
                return BadRequest(resultado.Mensaje);
            }
        }

        // PUT api/<ClienteController>
        [HttpPut]
        public async Task<IActionResult> Put(ClienteDto model)
        {
            var resultado = await servicio.ServicioCliente.ActualizarAsync(model);

            if (resultado.Correcto)
            {
                return Ok(resultado.Datos);
            }
            else
            {
                return BadRequest(resultado.Mensaje);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await servicio.ServicioCliente.EliminarAsync(id);

            if (resultado.Correcto)
            {
                return Ok(resultado.Datos);
            }
            else
            {
                return BadRequest(resultado.Mensaje);
            }
        }
    }
}