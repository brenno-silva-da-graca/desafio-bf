using desafio.Data;
using desafio.Models;
using desafio.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace desafio.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DesafioDBContext _dbContext;

        public VehicleRepository(DesafioDBContext desafioBDContext)
        {
            _dbContext = desafioBDContext;
        }

        public async Task<VehicleModel> GetVehicleById(int id)
        {
            return await _dbContext.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<VehicleModel>> Read()
        {
            return await _dbContext.Vehicles.ToListAsync();
        }

        public async Task<VehicleModel> Create(VehicleModel vehicle)
        {
            await _dbContext.Vehicles.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();

            return vehicle;
        }

        public async Task<VehicleModel> Update(VehicleModel vehicle, int id)
        {
            VehicleModel vehicleById = await GetVehicleById(id);

            if (vehicleById == null)
            {
                throw new Exception($"Veiculo com o ID {id} não encontrado no banco de dados!");
            }

            vehicleById.Year = vehicle.Year;
            vehicleById.Type = vehicle.Type;
            vehicleById.Brand = vehicle.Brand;
            vehicleById.Color = vehicle.Color;

            _dbContext.Vehicles.Update(vehicleById);
            await _dbContext.SaveChangesAsync();

            return vehicleById;
        }

        public async Task<bool> Delete(int id)
        {
            VehicleModel vehicleById = await GetVehicleById(id);

            if (vehicleById == null)
            {
                throw new Exception($"Veiculo com o ID {id} não encontrado no banco de dados!");
            }

            _dbContext.Vehicles.Remove(vehicleById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
