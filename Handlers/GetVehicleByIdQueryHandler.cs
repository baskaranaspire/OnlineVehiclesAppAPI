using MediatR;
using OnlineVehiclesApplication.DataTransferObjects;
using OnlineVehiclesApplication.Interfaces;
using OnlineVehiclesApplication.Queries;

namespace OnlineVehiclesApplication.Handlers
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, Vehicles>
    {
        private readonly IVehiclesRepository _repository;
        public GetVehicleByIdQueryHandler(IVehiclesRepository repository)
        {
                _repository  = repository;
        }
        public async Task<Vehicles> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.VehicleId);
        }
    }
}
