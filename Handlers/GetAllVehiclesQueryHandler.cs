using MediatR;
using OnlineVehiclesApplication.DataTransferObjects;
using OnlineVehiclesApplication.Interfaces;
using OnlineVehiclesApplication.Queries;

namespace OnlineVehiclesApplication.Handlers
{
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, List<Vehicles>>
    {
        private readonly IVehiclesRepository _repository;
        public GetAllVehiclesQueryHandler(IVehiclesRepository repository)
        {
                _repository = repository;
        }
        public async Task<List<Vehicles>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
