using backend_eva.Data;
using backend_eva.Models;
using Microsoft.AspNetCore.Mvc;
namespace backend_eva.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClienteController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult CrearCliente(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return Ok(cliente);
        }

        [HttpGet]
        public IActionResult ListarClientes()
        {
            var clientes = context.Clientes.ToList();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerCliente(int id)
        {
            var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarCliente(int id, Cliente clienteActualizado)
        {
            var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nombre = clienteActualizado.Nombre;
            cliente.Paterno = clienteActualizado.Paterno;
            cliente.Materno = clienteActualizado.Materno;
            cliente.TipoDocumento = clienteActualizado.TipoDocumento;
            cliente.NumeroDocumento = clienteActualizado.NumeroDocumento;
            cliente.FechaNacimiento = clienteActualizado.FechaNacimiento;
            cliente.Genero = clienteActualizado.Genero;

            context.SaveChanges();

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var cliente = context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            context.Clientes.Remove(cliente);
            context.SaveChanges();

            return Ok(cliente);
        }
    }
}
