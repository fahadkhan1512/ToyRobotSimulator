using Toy.Robot.Simulator.Enum;
using Toy.Robot.Simulator.Models;

namespace Toy.Robot.Simulator.InputParamConvertor.Interface
{
    public interface IParameterConvertor
    {
        string[] InputParameterConvertor(string inputParameter);

        Command CommandConvertor(string inputCommand);

        ToyLocation LocationConvertor(string inputLocation);
    }
}
