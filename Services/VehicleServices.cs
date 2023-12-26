using OnlineVehiclesApplication.DataTransferObjects;
using OnlineVehiclesApplication.Interfaces;

namespace OnlineVehiclesApplication.Services
{
    public class VehicleServices : IVehicleServices
    {
        private readonly IVehiclesRepository _repository;
        public VehicleServices(IVehiclesRepository repository)
        {
                _repository = repository;
        }
        public async Task<Vehicles> Create(Vehicles vehicles)
        {
            return await _repository.Create(vehicles);
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<Vehicles>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Vehicles> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Vehicles> Update(Vehicles vehicles)
        {
            return await _repository.Update(vehicles);
        }
    }
}
