using MediatR;
using OnlineVehiclesApplication.DataTransferObjects;

namespace OnlineVehiclesApplication.Commands
{
    public class CreateVehicleCommand : IRequest<Vehicles>
    {
        public Vehicles Vehicles { get; set; }
    }
}
