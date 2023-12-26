using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineVehiclesApplication.Commands;
using OnlineVehiclesApplication.DataTransferObjects;
using OnlineVehiclesApplication.Queries;

namespace OnlineVehiclesApplication.Controllers
{
    
    [Route("OnlineVehicles")]
    [ApiController]
    public class OnlineVehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OnlineVehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Vehicles>> GetAllVehicles()
        {
            return await _mediator.Send(new GetAllVehiclesQuery());
        }

        [HttpGet("{id}")]
        public async Task<Vehicles> GetVehicleById(string id)
        {
            return await _mediator.Send(new GetVehicleByIdQuery() { VehicleId = id});
        }

        [HttpPost]
        public async Task<Vehicles> CreateVehicle([FromBody] Vehicles Vehicle)
        {
            return await _mediator.Send(new CreateVehicleCommand() { Vehicles = Vehicle});
        }

        [HttpPut("{id}")]
        public async Task<Vehicles> UpdateVehicleById(string id, [FromBody] Vehicles Vehicle)
        {
            return await _mediator.Send(new UpdateVehicleByIdCommand() { Vehicles = Vehicle });
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteVehicleById(string id)
        {
            return await _mediator.Send(new DeleteVehicleByIdCommand() { VehicleId = id});
        }
    }
}
