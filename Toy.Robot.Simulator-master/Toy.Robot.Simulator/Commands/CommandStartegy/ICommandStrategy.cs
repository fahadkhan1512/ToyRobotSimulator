using Toy.Robot.Simulator.Enum;

namespace Toy.Robot.Simulator.Commands
{
    public interface ICommandStrategy
    {
        string ExecuteCommand(Command commands, string locationParameter);
    }
}
