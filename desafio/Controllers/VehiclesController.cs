using desafio.Models;
using desafio.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehiclesController(IVehicleRepository vehicleRepository) 
        {
            _vehicleRepository = vehicleRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<VehicleModel>>> GetAllVehicles()
        {
            List<VehicleModel> vehicles = await _vehicleRepository.Read();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> GetVehicleById(int id)
        {
            VehicleModel vehicle = await _vehicleRepository.GetVehicleById(id);
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleModel>> Create([FromBody] VehicleModel vehicleModel)
        {
            VehicleModel vehicle = await _vehicleRepository.Create(vehicleModel);
            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModel>> Update([FromBody] VehicleModel vehicleModel, int id)
        {
            vehicleModel.Id = id;
            VehicleModel vehicle = await _vehicleRepository.Update(vehicleModel, id);
            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> Delete(int id)
        {
            await _vehicleRepository.Delete(id);

            return Ok($"O veiculo {id}, foi apagado");
        }
    }
}
