using FluentAssertions;
using Rover.Driving.Api.Application;
using Rover.Driving.Api.Domain.Models;
using Rover.Driving.Api.Domain.Models.ResponseModels;
using Rover.Driving.Api.Infrastructure;
using Xunit;

namespace Rover.Driving.Api.Test
{
    public class SingleMovementTests
    {
        #region Moving Forward Tests
        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition00N_ShoudReturn01N()
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
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 0,
                VerticalPosition = 1
            });

            var realResult = sut.ProcessSingleMovement('F');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition00E_ShoudReturn10E()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 1,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('F');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition00S_ShoudReturn0m1S()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = -1
            });

            var realResult = sut.ProcessSingleMovement('F');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition00W_ShoudReturnm10W()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = -1,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('F');
            realResult.Should().BeEquivalentTo(expectedResult);
        }
        #endregion

        #region Moving Backwards Tests
        [Fact]
        public void ProcessSingleMovement_WhenBReceivedAndPosition00N_ShoudReturn0m1N()
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
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 0,
                VerticalPosition = -1
            });

            var realResult = sut.ProcessSingleMovement('B');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenBReceivedAndPosition00S_ShoudReturn01S()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = 1
            });

            var realResult = sut.ProcessSingleMovement('B');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenBReceivedAndPosition00E_ShoudReturnm10E()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = -1,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('B');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenBReceivedAndPosition00W_ShoudReturn10W()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 1,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('B');
            realResult.Should().BeEquivalentTo(expectedResult);
        }
        #endregion

        #region Left Rotation Tests

        [Fact]
        public void ProcessSingleMovement_WhenLReceivedAndPosition00N_ShoudReturn00W()
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
                HorizontalPosition = 0,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('L');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenLReceivedAndPosition00E_ShoudReturn00N()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 0,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('L');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenLReceivedAndPosition00S_ShoudReturn00E()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 0,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('L');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenLReceivedAndPosition00W_ShoudReturn00S()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('L');
            realResult.Should().BeEquivalentTo(expectedResult);
        }
        #endregion

        #region Right Rotation Tests

        [Fact]
        public void ProcessSingleMovement_WhenRReceivedAndPosition00N_ShoudReturn00E()
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
                HorizontalPosition = 0,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('R');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenRReceivedAndPosition00E_ShoudReturn00S()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('R');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenRReceivedAndPosition00S_ShoudReturn00W()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 0,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('R');
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenRReceivedAndPosition00W_ShoudReturn00N()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 0,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('R');
            realResult.Should().BeEquivalentTo(expectedResult);
        }
        #endregion

        #region Wrapping From One Edge to another (Forward)

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition00WIn100x100Grid_ShoudReturn98_0_W()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 98,
                VerticalPosition = 99
            });

            var realResult = sut.ProcessSingleMovement('F', true);
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition00SIn100x100Grid_ShoudReturn98_0_S()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 99,
                VerticalPosition = 98
            });

            var realResult = sut.ProcessSingleMovement('F', true);
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition_0_99_NIn100x100Grid_ShoudReturn_99_1_N()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 0,
                VerticalPosition = 99
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 99,
                VerticalPosition = 1
            });

            var realResult = sut.ProcessSingleMovement('F', true);
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition_0_99_WIn100x100Grid_ShoudReturn_98_0_W()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 0,
                VerticalPosition = 99
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.W,
                HorizontalPosition = 98,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('F', true);
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition_99_99_NIn100x100Grid_ShoudReturn_01N()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 99,
                VerticalPosition = 99
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.N,
                HorizontalPosition = 0,
                VerticalPosition = 1
            });

            var realResult = sut.ProcessSingleMovement('F', true);
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition_99_99_EIn100x100Grid_ShoudReturn_10E()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 99,
                VerticalPosition = 99
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 1,
                VerticalPosition = 0
            });

            var realResult = sut.ProcessSingleMovement('F', true);
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition_99_0_EIn100x100Grid_ShoudReturn_1_99E()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 99,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.E,
                HorizontalPosition = 1,
                VerticalPosition = 99
            });

            var realResult = sut.ProcessSingleMovement('F', true);
            realResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ProcessSingleMovement_WhenFReceivedAndPosition_99_0_SIn100x100Grid_ShoudReturn_0_98S()
        {
            var initialRoverPosition = new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 99,
                VerticalPosition = 0
            };

            RoverService roverService = new RoverService();
            roverService.SetInitialRoverPosition(initialRoverPosition);
            var sut = new RoverHandlingService(roverService);

            var expectedResult = new CommandProcessingResponse(new RoverPosition()
            {
                FacingDirection = Domain.Enums.CardinalDirection.S,
                HorizontalPosition = 0,
                VerticalPosition = 98
            });

            var realResult = sut.ProcessSingleMovement('F', true);
            realResult.Should().BeEquivalentTo(expectedResult);
        }
        #endregion

    }
}
