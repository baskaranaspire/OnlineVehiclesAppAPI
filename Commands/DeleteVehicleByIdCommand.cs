using MediatR;

namespace OnlineVehiclesApplication.Commands
{
    public class DeleteVehicleByIdCommand : IRequest<int>
    {
        public string VehicleId { get; set; }
    }
}
