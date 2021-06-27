using Microsoft.AspNetCore.Mvc;
using Rover.Driving.Api.Domain.Interfaces;
using Rover.Driving.Api.Domain.Models.ResponseModels;

namespace Rover.Driving.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingController : ControllerBase
    {
        private readonly IRoverHandlingService _roverHandlingService;
        public DrivingController(IRoverHandlingService roverHandlingService)
        {
            _roverHandlingService = roverHandlingService;
        }

        [HttpPost("ProcessMultipleCommandWithoutWrapping")]
        public CommandProcessingResponse ProcessMultipleCommand([FromBody] string command)
        {
            return _roverHandlingService.ProcessMultipleMovement(command);
        }

        [HttpPost("ProcessMultipleCommand")]
        public CommandProcessingResponse ProcessMultipleCommandWithWrapping([FromBody] string command)
        {
            return _roverHandlingService.ProcessMultipleMovement(command,true);
        }

        [HttpPost("ProcessSingleCommandWithoutWrapping")]
        public CommandProcessingResponse ProcessSingleCommand([FromBody] char command)
        {
            return _roverHandlingService.ProcessSingleMovement(command);
        }

        [HttpPost("ProcessSingleCommand")]
        public CommandProcessingResponse ProcessSingleCommandWithWrapping([FromBody] char command)
        {
            return _roverHandlingService.ProcessSingleMovement(command, true);
        }
    }
}
