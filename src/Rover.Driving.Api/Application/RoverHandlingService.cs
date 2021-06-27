using Rover.Driving.Api.Domain.Interfaces;
using Rover.Driving.Api.Domain.Models;
using Rover.Driving.Api.Domain.Models.ResponseModels;
using System;

namespace Rover.Driving.Api.Application
{
    public class RoverHandlingService : IRoverHandlingService
    {
        private readonly IRoverService _roverService;
        public RoverHandlingService(IRoverService roverService)
        {
            _roverService = roverService;
        }

        public CommandProcessingResponse ProcessMultipleMovement(string command, bool wrapping = false)
        {
            if (!string.IsNullOrWhiteSpace(command))
            {
                var result = new CommandProcessingResponse();
                var movements = command.ToUpper().ToCharArray();
                foreach (var movement in movements)
                {
                    result = ProcessSingleMovement(movement, wrapping);
                    if (result.DetectedError) return result;
                }
                return result;
            }
            else
            {
                return new CommandProcessingResponse()
                {
                    CurrentRoverPosition = new RoverPosition().ToString(),
                    DetectedError = true,
                    ErrorMessage = "Invalid input, please check the input command"
                };
            }
        }

        public CommandProcessingResponse ProcessSingleMovement(char command, bool wrapping = false)
        {
            var result = new CommandProcessingResponse();
            try
            {
                RoverPosition previousPosition = new RoverPosition(
                _roverService.GetRoverPosition().HorizontalPosition,
                _roverService.GetRoverPosition().VerticalPosition,
                _roverService.GetRoverPosition().FacingDirection
            );

                var newPosition = _roverService.GetRoverPosition();
                if (!_roverService.DetectObstacle())
                {
                    switch (command)
                    {
                        case 'F':
                            if (wrapping) //Only for testing.
                            {
                                newPosition = _roverService.MoveForwardWithWrapping();
                            }
                            else
                            {
                                newPosition = _roverService.MoveForward();
                            }
                            break;
                        case 'B':
                            if (wrapping) //Only for testing.
                            {
                                newPosition = _roverService.MoveBackwardWithWrapping();
                            }
                            else
                            {
                                newPosition = _roverService.MoveBackward();
                            }
                            break;
                        case 'L':
                            newPosition = _roverService.RotateLeft();
                            break;
                        case 'R':
                            newPosition = _roverService.RotateRight();
                            break;
                        default:
                            return new CommandProcessingResponse()
                            {
                                CurrentRoverPosition = new RoverPosition().ToString(),
                                DetectedError = true,
                                ErrorMessage = $"Invalid input: {command}!"
                            };
                    }

                    if (newPosition.Equals(previousPosition))
                    {
                        result.DetectedError = true;
                        result.ErrorMessage = $"Error moving {command} in position {previousPosition.ToString()}";
                        result.CurrentRoverPosition = _roverService.GetRoverPosition().ToString();
                    }
                    else
                    {
                        result.CurrentRoverPosition = newPosition.ToString();
                    }
                }
                else
                {
                    result.DetectedError = true;
                    result.ErrorMessage = $"Obstacle detected while trying to move {command} in position {previousPosition.ToString()}";
                    result.CurrentRoverPosition = _roverService.GetRoverPosition().ToString();
                }
                return result;
            }
            catch(Exception ex)
            {
                return new CommandProcessingResponse()
                {
                    CurrentRoverPosition = new RoverPosition().ToString(),
                    DetectedError = true,
                    ErrorMessage = $"Exception performing Rover action: {ex}"
                };
            }
        }
    }
}
