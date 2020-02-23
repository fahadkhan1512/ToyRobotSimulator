using System;
using Microsoft.Extensions.DependencyInjection;
using Toy.Robot.Simulator.Commands;
using Toy.Robot.Simulator.Commands.Implementation;
using Toy.Robot.Simulator.Commands.Interface;
using Toy.Robot.Simulator.InputParamConvertor.Implementation;
using Toy.Robot.Simulator.InputParamConvertor.Interface;
using Toy.Robot.Simulator.RobotSystem.Implementation;
using Toy.Robot.Simulator.RobotSystem.Interface;
using Toy.Robot.Simulator.TableTop.Implementation;
using Toy.Robot.Simulator.TableTop.Interface;

namespace Toy.Robot.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            //.AddLogging()
            .AddSingleton<ICommandExecutor, LeftCommandExecutor>()
            .AddSingleton<ICommandExecutor, MoveCommandExecutor>()
            .AddSingleton<ICommandExecutor, PlaceCommandExecutor>()
            .AddSingleton<ICommandExecutor, RightCommandExecutor>()
            .AddSingleton<ICommandStrategy, CommandStrategy>()
            .AddSingleton<IParameterConvertor, ParameterConvertor>()
            .AddSingleton<IRobotControlProcessor, RobotControlProcessor>()
            .AddSingleton<IToyTable>(x => new ToyTable(5, 5))
            .BuildServiceProvider();

            var processor = serviceProvider.GetService<IRobotControlProcessor>();

            const string caption = @"Please enter the command to the following format: 
                                    1. PLACE X,Y,FACING : To initiate the robot 
                                    2. MOVE             : To move the robot 
                                    3. RIGHT            : To move the robot right side 
                                    4. LEFT             : To move the robot left side 
                                    5. REPORT           : To get robot current location ";

            Console.WriteLine(caption);
            while (true)
            {
                var input = Console.ReadLine();
                if (input != null && input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                try
                {
                    var response = processor.ExecuteCommand(input);

                    if (!string.IsNullOrEmpty(response))
                        Console.WriteLine(response);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
