using MediatR;
using OnlineVehiclesApplication.Commands;
using OnlineVehiclesApplication.DataTransferObjects;
using OnlineVehiclesApplication.Interfaces;

namespace OnlineVehiclesApplication.Handlers
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Vehicles>
    {
        private readonly IVehiclesRepository _repository;
        public CreateVehicleCommandHandler(IVehiclesRepository repository)
        {
            _repository = repository;
         }
        public async Task<Vehicles> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Create(request.Vehicles);
        }
    }
}
