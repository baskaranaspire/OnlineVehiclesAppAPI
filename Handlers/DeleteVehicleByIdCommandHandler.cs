using MediatR;
using OnlineVehiclesApplication.Commands;
using OnlineVehiclesApplication.Interfaces;

namespace OnlineVehiclesApplication.Handlers
{
    public class DeleteVehicleByIdCommandHandler : IRequestHandler<DeleteVehicleByIdCommand , int>
    {
        private readonly IVehiclesRepository _repository;
        public DeleteVehicleByIdCommandHandler(IVehiclesRepository repository)
        {
                _repository = repository;
        }

        public async Task<int> Handle(DeleteVehicleByIdCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _repository.GetByIdAsync(request.VehicleId);
            if (vehicle == null)
            {
                return 0;
            }
            return await _repository.DeleteAsync(request.VehicleId);
        }
    }
}
