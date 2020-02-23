using Toy.Robot.Simulator.Enum;

namespace Toy.Robot.Simulator.Models
{
    public class ToyLocation
    {
        public Direction Direction;

        public Position Position;

        public ToyLocation(Direction direction, Position position)
        {
            Direction = direction;
            Position = position;
        }
    }
}
