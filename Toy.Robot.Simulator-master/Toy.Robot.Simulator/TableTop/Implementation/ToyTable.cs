﻿using Toy.Robot.Simulator.Models;
using Toy.Robot.Simulator.TableTop.Interface;

namespace Toy.Robot.Simulator.TableTop.Implementation
{
    public class ToyTable : IToyTable
    {
        public readonly int Width;
        public readonly int Depth;

        public ToyTable(int width, int depth)
        {
            Width = width;
            Depth = depth;
        }

        public bool CanMoveToNewPosition(Position newPosition) => newPosition.Y > -1
                    && newPosition.Y < Depth
                    && newPosition.X > -1
                    && newPosition.X < Width;
    }
}
