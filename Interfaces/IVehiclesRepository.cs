using OnlineVehiclesApplication.DataTransferObjects;

namespace OnlineVehiclesApplication.Interfaces
{
    public interface IVehiclesRepository
    {
        public Task<List<Vehicles>> GetAllAsync();
        public Task<Vehicles> GetByIdAsync(string id);
        public Task<Vehicles> Create(Vehicles vehicles);
        public Task<Vehicles> Update(Vehicles vehicles);
        public Task<int> DeleteAsync(string id);
    }
}
