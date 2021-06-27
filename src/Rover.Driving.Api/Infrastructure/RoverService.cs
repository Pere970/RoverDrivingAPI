using Rover.Driving.Api.Domain.Enums;
using Rover.Driving.Api.Domain.Interfaces;
using Rover.Driving.Api.Domain.Models;

namespace Rover.Driving.Api.Infrastructure
{
    public class RoverService : IRoverService
    {
        public readonly Domain.Models.Rover _rover;
        private readonly int MaximumHorizontalPosition;
        private readonly int MaximumVerticalPosition;
        private readonly int MinimumHorizontalPosition;
        private readonly int MinimumVerticalPosition;

        public RoverService(int maximumHorizontalPosition = 100, int maximumVerticalPosition = 100)
        {
            _rover = new Domain.Models.Rover();
            MaximumHorizontalPosition = maximumHorizontalPosition;
            MaximumVerticalPosition = maximumVerticalPosition;
            MinimumHorizontalPosition = 0;
            MinimumVerticalPosition = 0;
        }

        //This method would be removed in a "real world case" as you must considere the sphere figure. Only here for tests
        public RoverPosition MoveForward() 
        {
            switch (_rover.CurrentPosition.FacingDirection)
            {
                case CardinalDirection.N:
                    _rover.CurrentPosition.VerticalPosition++;
                    break;
                case CardinalDirection.S:
                    _rover.CurrentPosition.VerticalPosition--;
                    break;
                case CardinalDirection.E:
                    _rover.CurrentPosition.HorizontalPosition++;
                    break;
                case CardinalDirection.W:
                    _rover.CurrentPosition.HorizontalPosition--;
                    break;
            }
            return _rover.CurrentPosition;
        }

        //This method would be removed in a "real world case" as you must considere the sphere figure. Only here for tests
        public RoverPosition MoveBackward()
        {
            switch (_rover.CurrentPosition.FacingDirection)
            {
                case CardinalDirection.N:
                    _rover.CurrentPosition.VerticalPosition--;
                    break;
                case CardinalDirection.S:
                    _rover.CurrentPosition.VerticalPosition++;
                    break;
                case CardinalDirection.E:
                    _rover.CurrentPosition.HorizontalPosition--;
                    break;
                case CardinalDirection.W:
                    _rover.CurrentPosition.HorizontalPosition++;
                    break;
            }
            return _rover.CurrentPosition;
        }

        public RoverPosition RotateLeft()
        {
            switch (_rover.CurrentPosition.FacingDirection)
            {
                case CardinalDirection.N:
                    _rover.CurrentPosition.FacingDirection = CardinalDirection.W;
                    break;
                case CardinalDirection.S:
                    _rover.CurrentPosition.FacingDirection = CardinalDirection.E;
                    break;
                case CardinalDirection.E:
                    _rover.CurrentPosition.FacingDirection = CardinalDirection.N;
                    break;
                case CardinalDirection.W:
                    _rover.CurrentPosition.FacingDirection = CardinalDirection.S;
                    break;
            }
            return _rover.CurrentPosition;
        }

        public RoverPosition RotateRight()
        {
            switch (_rover.CurrentPosition.FacingDirection)
            {
                case CardinalDirection.N:
                    _rover.CurrentPosition.FacingDirection = CardinalDirection.E;
                    break;
                case CardinalDirection.S:
                    _rover.CurrentPosition.FacingDirection = CardinalDirection.W;
                    break;
                case CardinalDirection.E:
                    _rover.CurrentPosition.FacingDirection = CardinalDirection.S;
                    break;
                case CardinalDirection.W:
                    _rover.CurrentPosition.FacingDirection = CardinalDirection.N;
                    break;
            }
            return _rover.CurrentPosition;
        }

        //This method would be renamed to MoveBackward once the actual MoveBackward was removed
        public RoverPosition MoveBackwardWithWrapping()
        {
            switch (_rover.CurrentPosition.FacingDirection)
            {
                case CardinalDirection.N:
                    if (_rover.CurrentPosition.HorizontalPosition == MinimumHorizontalPosition
                        && _rover.CurrentPosition.VerticalPosition == MinimumVerticalPosition)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MaximumHorizontalPosition - 1;
                        _rover.CurrentPosition.VerticalPosition = MaximumVerticalPosition - 2;
                    }
                    else if (_rover.CurrentPosition.HorizontalPosition == MaximumHorizontalPosition - 1
                        && _rover.CurrentPosition.VerticalPosition == MinimumVerticalPosition)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MinimumHorizontalPosition;
                        _rover.CurrentPosition.VerticalPosition = MaximumVerticalPosition - 2;
                    }
                    else
                    {
                        _rover.CurrentPosition.VerticalPosition--;
                    }
                    break;
                case CardinalDirection.S:
                    if (_rover.CurrentPosition.HorizontalPosition == MinimumHorizontalPosition
                        && _rover.CurrentPosition.VerticalPosition == MaximumVerticalPosition - 1)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MaximumHorizontalPosition - 1;
                        _rover.CurrentPosition.VerticalPosition = MinimumVerticalPosition + 1;
                    }
                    else if (_rover.CurrentPosition.HorizontalPosition == MaximumHorizontalPosition - 1
                        && _rover.CurrentPosition.VerticalPosition == MaximumVerticalPosition - 1)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MinimumHorizontalPosition;
                        _rover.CurrentPosition.VerticalPosition = MinimumVerticalPosition + 1;
                    }
                    else
                    {
                        _rover.CurrentPosition.VerticalPosition++;
                    }
                    break;
                case CardinalDirection.E:
                    if (_rover.CurrentPosition.HorizontalPosition == MinimumHorizontalPosition
                        && _rover.CurrentPosition.VerticalPosition == MaximumVerticalPosition - 1)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MaximumHorizontalPosition - 2;
                        _rover.CurrentPosition.VerticalPosition = MinimumVerticalPosition;
                    }
                    else if (_rover.CurrentPosition.HorizontalPosition == MinimumHorizontalPosition
                        && _rover.CurrentPosition.VerticalPosition == MinimumVerticalPosition)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MaximumHorizontalPosition - 2;
                        _rover.CurrentPosition.VerticalPosition = MaximumVerticalPosition - 1;
                    }
                    else
                    {
                        _rover.CurrentPosition.HorizontalPosition--;
                    }
                    break;
                case CardinalDirection.W:
                    if (_rover.CurrentPosition.HorizontalPosition == MaximumHorizontalPosition - 1
                        && _rover.CurrentPosition.VerticalPosition == MaximumVerticalPosition - 1)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MinimumHorizontalPosition + 1;
                        _rover.CurrentPosition.VerticalPosition = MinimumVerticalPosition;
                    }
                    else if (_rover.CurrentPosition.HorizontalPosition == MaximumHorizontalPosition - 1
                        && _rover.CurrentPosition.VerticalPosition == MinimumVerticalPosition)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MinimumHorizontalPosition + 1;
                        _rover.CurrentPosition.VerticalPosition = MaximumVerticalPosition - 1;
                    }
                    else
                    {
                        _rover.CurrentPosition.HorizontalPosition++;
                    }
                    break;
            }
            return _rover.CurrentPosition;
        }


        //This method would be renamed to MoveForward once the actual MoveForward was removed
        public RoverPosition MoveForwardWithWrapping()
        {
            switch (_rover.CurrentPosition.FacingDirection)
            {
                case CardinalDirection.N:
                    if (_rover.CurrentPosition.HorizontalPosition == MaximumHorizontalPosition - 1
                        && _rover.CurrentPosition.VerticalPosition == MaximumVerticalPosition - 1)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MinimumHorizontalPosition;
                        _rover.CurrentPosition.VerticalPosition = MinimumVerticalPosition + 1;
                    }
                    else if (_rover.CurrentPosition.HorizontalPosition == MinimumHorizontalPosition
                        && _rover.CurrentPosition.VerticalPosition == MaximumVerticalPosition - 1)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MaximumHorizontalPosition - 1;
                        _rover.CurrentPosition.VerticalPosition = MinimumVerticalPosition + 1;
                    }
                    else
                    {
                        _rover.CurrentPosition.VerticalPosition++;
                    }
                    break;
                case CardinalDirection.S:
                    if (_rover.CurrentPosition.HorizontalPosition == MinimumHorizontalPosition
                        && _rover.CurrentPosition.VerticalPosition == MinimumVerticalPosition)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MaximumHorizontalPosition - 1;
                        _rover.CurrentPosition.VerticalPosition = MaximumVerticalPosition - 2;
                    }
                    else if (_rover.CurrentPosition.HorizontalPosition == MaximumHorizontalPosition - 1
                        && _rover.CurrentPosition.VerticalPosition == MinimumVerticalPosition)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MinimumHorizontalPosition;
                        _rover.CurrentPosition.VerticalPosition = MaximumVerticalPosition - 2;
                    }
                    else
                    {
                        _rover.CurrentPosition.VerticalPosition--;
                    }
                    break;
                case CardinalDirection.E:
                    if (_rover.CurrentPosition.HorizontalPosition == MaximumHorizontalPosition - 1
                        && _rover.CurrentPosition.VerticalPosition == MaximumVerticalPosition - 1)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MinimumHorizontalPosition + 1;
                        _rover.CurrentPosition.VerticalPosition = MinimumVerticalPosition;
                    }
                    else if (_rover.CurrentPosition.HorizontalPosition == MaximumHorizontalPosition - 1
                        && _rover.CurrentPosition.VerticalPosition == MinimumVerticalPosition)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MinimumHorizontalPosition + 1;
                        _rover.CurrentPosition.VerticalPosition = MaximumVerticalPosition - 1;
                    }
                    else
                    {
                        _rover.CurrentPosition.HorizontalPosition++;
                    }
                    break;
                case CardinalDirection.W:
                    if (_rover.CurrentPosition.HorizontalPosition == MinimumHorizontalPosition
                        && _rover.CurrentPosition.VerticalPosition == MinimumVerticalPosition)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MaximumHorizontalPosition - 2;
                        _rover.CurrentPosition.VerticalPosition = MaximumVerticalPosition - 1;
                    }
                    else if (_rover.CurrentPosition.HorizontalPosition == MinimumHorizontalPosition
                        && _rover.CurrentPosition.VerticalPosition == MaximumVerticalPosition - 1)
                    {
                        _rover.CurrentPosition.HorizontalPosition = MaximumHorizontalPosition - 2;
                        _rover.CurrentPosition.VerticalPosition = MinimumVerticalPosition;
                    }
                    else
                    {
                        _rover.CurrentPosition.HorizontalPosition--;
                    }
                    break;
            }
            return _rover.CurrentPosition;
        }

        
        //Could not mock this method in the testing (Check Feedback Survey for more info.)
        public bool DetectObstacle()
        {
            /*
             Here would be the code for obstacle detection if there was a "Planet" definition 
             with its own obstacles spread over the grid
             */
            return false;
        }

        public RoverPosition GetRoverPosition()
        {
            return _rover.CurrentPosition;
        }

        public RoverPosition SetInitialRoverPosition(RoverPosition position)
        {
            _rover.CurrentPosition.HorizontalPosition = position.HorizontalPosition;
            _rover.CurrentPosition.VerticalPosition = position.VerticalPosition;
            _rover.CurrentPosition.FacingDirection = position.FacingDirection;
            return position;
        }
    }
}
