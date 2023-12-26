using MediatR;
using OnlineVehiclesApplication.DataTransferObjects;

namespace OnlineVehiclesApplication.Queries
{
    public class GetVehicleByIdQuery : IRequest<Vehicles>
    {
        public string VehicleId { get; set; }
    }
}
