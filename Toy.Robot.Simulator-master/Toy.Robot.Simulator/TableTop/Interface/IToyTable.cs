using Toy.Robot.Simulator.Models;

namespace Toy.Robot.Simulator.TableTop.Interface
{
    public interface IToyTable
    {
        bool CanMoveToNewPosition(Position newPosition);
    }
}
