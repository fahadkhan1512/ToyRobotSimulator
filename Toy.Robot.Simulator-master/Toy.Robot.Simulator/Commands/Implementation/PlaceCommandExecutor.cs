using System.Linq;
using System.Runtime.InteropServices;
using Toy.Robot.Simulator.Commands.Interface;
using Toy.Robot.Simulator.Enum;
using Toy.Robot.Simulator.InputParamConvertor.Interface;
using Toy.Robot.Simulator.Models;
using Toy.Robot.Simulator.TableTop.Interface;

namespace Toy.Robot.Simulator.Commands.Implementation
{
    public class PlaceCommandExecutor : ICommandExecutor
    {
        private readonly IParameterConvertor parameterConvertor;
        private readonly IToyTable toyTable;
        public Command Command => Command.Place;

        public PlaceCommandExecutor(IParameterConvertor parameterConvertor, IToyTable toyTable)
        {
            this.parameterConvertor = parameterConvertor;
            this.toyTable = toyTable;
        }

        public ToyLocation Operator(ToyLocation currentToyLocation, [Optional] string parameter)
        {
            var intputParameters = parameterConvertor.InputParameterConvertor(parameter);

            var location = parameterConvertor.LocationConvertor(intputParameters.Last());

            if (!toyTable.CanMoveToNewPosition(location.Position))
            {
                return currentToyLocation;
            }
            var toyLocation = new ToyLocation(location.Direction, location.Position);

            return new ToyLocation(toyLocation.Direction
                                    , toyLocation.Position);
        }
    }
}
