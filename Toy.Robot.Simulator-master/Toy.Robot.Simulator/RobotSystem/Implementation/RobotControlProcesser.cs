using System.Linq;
using Toy.Robot.Simulator.Commands;
using Toy.Robot.Simulator.InputParamConvertor.Interface;
using Toy.Robot.Simulator.RobotSystem.Interface;

namespace Toy.Robot.Simulator.RobotSystem.Implementation
{
    public class RobotControlProcessor : IRobotControlProcessor
    {
        private readonly IParameterConvertor _parameterConvertor;
        private readonly ICommandStrategy _commandStrategy;


        public RobotControlProcessor(IParameterConvertor parameterConvertor, ICommandStrategy commandStrategy)
        {
            this._parameterConvertor = parameterConvertor;
            this._commandStrategy = commandStrategy;
        }

        public string ExecuteCommand(string inputParameter)
        {
            var input = inputParameter.Split(' ').FirstOrDefault();
            var command = _parameterConvertor.CommandConvertor(input);

            var result = _commandStrategy.ExecuteCommand(command, inputParameter);

            return result;
        }
    }
}
