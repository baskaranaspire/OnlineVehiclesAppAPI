using MediatR;
using OnlineVehiclesApplication.DataTransferObjects;

namespace OnlineVehiclesApplication.Commands
{
    public class UpdateVehicleByIdCommand : IRequest<Vehicles>
    {
        public Vehicles Vehicles { get; set; }
    }
}
