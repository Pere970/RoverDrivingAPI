using Rover.Driving.Api.Domain.Enums;

namespace Rover.Driving.Api.Domain.Models
{
    public class RoverPosition
    {
        public int HorizontalPosition { get; set; }
        public int VerticalPosition { get; set; }
        public CardinalDirection FacingDirection { get; set; }

        public RoverPosition()
        {
            HorizontalPosition = 0;
            VerticalPosition = 0;
            FacingDirection = CardinalDirection.N;
        }

        public RoverPosition(int horizontalPosition, int verticalPosition, CardinalDirection facingDirection)
        {
            HorizontalPosition = horizontalPosition;
            VerticalPosition = verticalPosition;
            FacingDirection = facingDirection;
        }

        public override string ToString()
        {
            return $"[{HorizontalPosition},{VerticalPosition},{FacingDirection}]";
        }
    }
}
