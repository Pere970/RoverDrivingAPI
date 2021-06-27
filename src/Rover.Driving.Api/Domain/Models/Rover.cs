namespace Rover.Driving.Api.Domain.Models
{
    public class Rover
    {
        public RoverPosition CurrentPosition { get; }
        public Rover(RoverPosition initialRoverPosition)
        {
            CurrentPosition = initialRoverPosition;
        }
        public Rover() {
            CurrentPosition = new RoverPosition();
        }
    }
}
