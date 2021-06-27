using Rover.Driving.Api.Domain.Models;

namespace Rover.Driving.Api.Domain.Interfaces
{
    public interface IRoverService
    {
        RoverPosition MoveForward();
        RoverPosition MoveBackward();
        RoverPosition RotateLeft();
        RoverPosition RotateRight();
        RoverPosition MoveBackwardWithWrapping();
        RoverPosition MoveForwardWithWrapping();
        bool DetectObstacle();
        RoverPosition GetRoverPosition();
        RoverPosition SetInitialRoverPosition(RoverPosition position);
    }
}
