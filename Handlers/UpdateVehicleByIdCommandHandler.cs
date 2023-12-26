using MediatR;
using OnlineVehiclesApplication.Commands;
using OnlineVehiclesApplication.DataTransferObjects;
using OnlineVehiclesApplication.Interfaces;

namespace OnlineVehiclesApplication.Handlers
{
    public class UpdateVehicleByIdCommandHandler : IRequestHandler<UpdateVehicleByIdCommand, Vehicles>
    {
        private readonly IVehiclesRepository _repository;
        public UpdateVehicleByIdCommandHandler(IVehiclesRepository repository)
        {
            _repository = repository;
        }
        public async Task<Vehicles> Handle(UpdateVehicleByIdCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Update(request.Vehicles);
        }
    }
}
