using Rover.Driving.Api.Domain.Models.ResponseModels;

namespace Rover.Driving.Api.Domain.Interfaces
{
    public interface IRoverHandlingService
    {
        public CommandProcessingResponse ProcessSingleMovement(char command, bool wrapping = false);
        public CommandProcessingResponse ProcessMultipleMovement(string command, bool wrapping = false);
    }
}
