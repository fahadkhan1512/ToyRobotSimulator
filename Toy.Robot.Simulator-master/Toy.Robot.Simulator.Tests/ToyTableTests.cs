using FluentAssertions;
using Moq;
using Toy.Robot.Simulator.Models;
using Toy.Robot.Simulator.TableTop.Implementation;
using Toy.Robot.Simulator.TableTop.Interface;
using Xunit;

namespace Toy.Robot.Simulator.Tests
{
    public class ToyTableTests 
    {
        private readonly IToyTable _toyTable;

        public ToyTableTests() => _toyTable = new Mock<ToyTable>(5, 5).Object;

        [Fact]
        public void Check_Table_Position_Invalid()
        {
            // Assign
            var position = new Position(9, 7);

            // Act 
            var expected = _toyTable.CanMoveToNewPosition(position);

            // Assert
            expected.Should().BeFalse();
        }

        [Fact]
        public void Check_Table_Position_valid()
        {
            // Assign
            var position = new Position(2, 3);
           
            // Act 
            var expected = _toyTable.CanMoveToNewPosition(position);

            // Assert
            expected.Should().BeTrue();
        }
    }
}
