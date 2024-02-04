using desafio.Models;

namespace desafio.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<VehicleModel> GetVehicleById(int id);
        Task<VehicleModel> Create(VehicleModel vehicles);
        Task<List<VehicleModel>> Read();
        Task<VehicleModel> Update(VehicleModel vehicle, int id);
        Task<bool> Delete(int id);
    }
}
