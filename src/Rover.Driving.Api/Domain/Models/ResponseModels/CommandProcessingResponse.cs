namespace Rover.Driving.Api.Domain.Models.ResponseModels
{
    public class CommandProcessingResponse
    {
        public bool DetectedError { get; set; }
        public string? ErrorMessage { get; set; }
        public string CurrentRoverPosition { get; set; }

        public CommandProcessingResponse(RoverPosition newRoverPosition, bool detectedError = false, string? errorMessage = null)
        {
            CurrentRoverPosition = newRoverPosition.ToString();
            DetectedError = detectedError;
            ErrorMessage = errorMessage;
        }

        public CommandProcessingResponse()
        {
            CurrentRoverPosition = new RoverPosition().ToString();
        }
    }
}
