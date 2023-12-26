using MediatR;
using OnlineVehiclesApplication.DataTransferObjects;

namespace OnlineVehiclesApplication.Queries
{
    public class GetAllVehiclesQuery : IRequest<List<Vehicles>>
    {
    }
}
