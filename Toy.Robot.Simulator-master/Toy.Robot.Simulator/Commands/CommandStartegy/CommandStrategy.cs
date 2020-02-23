﻿namespace Toy.Robot.Simulator.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Toy.Robot.Simulator.Commands.Interface;
    using Toy.Robot.Simulator.Enum;
    using Toy.Robot.Simulator.Models;

    public class CommandStrategy : ICommandStrategy
    {
        private readonly IEnumerable<ICommandExecutor> _commandExecutor;
        public ToyLocation ToyLocation { get; set; }

        public CommandStrategy(IEnumerable<ICommandExecutor> commandExecutor) => this._commandExecutor = commandExecutor;

        public string ExecuteCommand(Command command, string locationParameter)
        {
            if ((Command.Report == command) && (ToyLocation != null))
            {
                return $"Output: {ToyLocation.Position.X},{ToyLocation.Position.Y},{ToyLocation.Direction.ToString()}";
            }

            ToyLocation location = this._commandExecutor.FirstOrDefault(x => x.Command == command)
                            ?.Operator(ToyLocation, locationParameter);
                           

            this.ToyLocation = location;

            return string.Empty;
        }
    }
}

