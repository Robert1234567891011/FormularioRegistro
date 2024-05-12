using backend_eva.Data;
using backend_eva.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace backend_eva.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public VehiculoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult CrearVehiculo(Vehiculo vehiculo)
        {
            context.Vehiculo.Add(vehiculo);
            context.SaveChanges();
            return Ok(vehiculo);
        }

        [HttpGet]
        public IActionResult ListarVehiculos()
        {
            var vehiculos = context.Vehiculo.ToList();
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerVehiculo(int id)
        {
            var vehiculo = context.Vehiculo.FirstOrDefault(v => v.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return Ok(vehiculo);
        }

        [HttpPut("{id}")]
        public IActionResult ModificarVehiculo(int id, Vehiculo vehiculoActualizado)
        {
            var vehiculo = context.Vehiculo.FirstOrDefault(v => v.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            vehiculo.Marca = vehiculoActualizado.Marca;
            vehiculo.Modelo = vehiculoActualizado.Modelo;
            vehiculo.Anio = vehiculoActualizado.Anio;
            vehiculo.Placa = vehiculoActualizado.Placa;

            context.SaveChanges();

            return Ok(vehiculo);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarVehiculo(int id)
        {
            var vehiculo = context.Vehiculo.FirstOrDefault(v => v.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            context.Vehiculo.Remove(vehiculo);
            context.SaveChanges();

            return Ok(vehiculo);
        }
    }
}
