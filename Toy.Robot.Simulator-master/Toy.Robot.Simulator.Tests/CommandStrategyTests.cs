using System.Collections.Generic;
using FluentAssertions;
using Toy.Robot.Simulator.Commands;
using Toy.Robot.Simulator.Commands.Implementation;
using Toy.Robot.Simulator.Commands.Interface;
using Toy.Robot.Simulator.Enum;
using Toy.Robot.Simulator.InputParamConvertor.Implementation;
using Toy.Robot.Simulator.TableTop.Implementation;
using Xunit;

namespace Toy.Robot.Simulator.Tests
{
    public class CommandStrategyTests 
    {
        private readonly List<ICommandExecutor> _commandExecutor;
        private readonly CommandStrategy _commandStrategy;

        public CommandStrategyTests() 
        {
            _commandExecutor = new List<ICommandExecutor>();
            _commandExecutor.Add(new LeftCommandExecutor());
            _commandExecutor.Add(new MoveCommandExecutor(new ToyTable(5, 5)));
            var parameterConvertor = new ParameterConvertor();
            _commandExecutor.Add(new PlaceCommandExecutor(parameterConvertor, new ToyTable(5, 5)));
            _commandExecutor.Add(new RightCommandExecutor());

            _commandStrategy = new CommandStrategy(_commandExecutor);
        }

        [Fact]
        public void Place_Command_Invalid_Test()
        {
            // Assign
            var command = Command.Place;
            
            // Act 
            _commandStrategy.ExecuteCommand(command, "PLACE 6,8,NORTH");

            // Assert
            _commandStrategy.ToyLocation.Should().BeNull();
        }

        [Fact]
        public void Place_Command_valid_Test()
        {
            // Assign
            var command = Command.Place;

            // Act 
            _commandStrategy.ExecuteCommand(command, "PLACE 0,0,NORTH");
            command = Command.Report;
            var result = _commandStrategy.ExecuteCommand(command, "REPORT");

            // Assert
            result.Should().BeEquivalentTo("Output: 0,0,NORTH");
        }

        [Fact]
        public void Move_Command_Out_Table_Test()
        {
            // Assign
            var command = Command.Place;

            // Act 
            _commandStrategy.ExecuteCommand(command, "Place 3,3,NORTH");
            command = Command.Move;
            _commandStrategy.ExecuteCommand(command, "Move");
            _commandStrategy.ExecuteCommand(command, "Move");
            _commandStrategy.ExecuteCommand(command, "Move");
            _commandStrategy.ExecuteCommand(command, "Move");
            _commandStrategy.ExecuteCommand(command, "Move");
            command = Command.Report;
            var result = _commandStrategy.ExecuteCommand(command, "REPORT");

            // Assert
            result.Should().BeEquivalentTo("Output: 3,4,NORTH");
        }

        [Fact]
        public void Right_Command_Valid_Test()
        {
            // Assign
            var command = Command.Place;

            // Act 
            _commandStrategy.ExecuteCommand(command, "Place 0,0,NORTH");
            command = Command.Right;
            _commandStrategy.ExecuteCommand(command, "Right");
            _commandStrategy.ExecuteCommand(command, "Right");
            _commandStrategy.ExecuteCommand(command, "Right");

            command = Command.Report;
            var result = _commandStrategy.ExecuteCommand(command, "REPORT");

            // Assert
            result.Should().BeEquivalentTo("Output: 0,0,West");
        }

        [Fact]
        public void Left_Command_Valid_Test()
        {
            // Assign
            var command = Command.Place;

            // Act 
            _commandStrategy.ExecuteCommand(command, "Place 0,0,NORTH");
            command = Command.Left;
            _commandStrategy.ExecuteCommand(command, "Left");
            _commandStrategy.ExecuteCommand(command, "Left");
            _commandStrategy.ExecuteCommand(command, "Left");

            command = Command.Report;
            var result = _commandStrategy.ExecuteCommand(command, "REPORT");

            // Assert
            result.Should().BeEquivalentTo("Output: 0,0,East");
        }
    }
}