using FluentAssertions;
using Rover.Driving.Api.Application;
using Rover.Driving.Api.Domain.Models;
using Rover.Driving.Api.Domain.Models.ResponseModels;
using Rover.Driving.Api.Infrastructure;
using Xunit;

namespace Rover.Driving.Api.Test
{
    public class MultipleMovementTests
    {

        [Fact]
        public void ProcessMultipleMovement_WhenFFRFFReceivedAndPosition00N_ShoudReturn22E()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 2,
                VerticalPosition = 2
            });

            var realResult = sut.ProcessMultipleMovement("FFRFF");
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessMultipleMovement_WhenJJKKReceivedAndPosition00N_ShouldReturnInputError()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(
                new RoverPosition(),
                true,
                "Invalid input: J!"
            );

            var realResult = sut.ProcessMultipleMovement("JJKK");
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessMultipleMovement_WhenBBLFFReceivedAndPosition00N_ShouldReturn99_99_W()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 97,
                VerticalPosition = 97
            });

            var realResult = sut.ProcessMultipleMovement("BBLFF",true);
            realResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}
