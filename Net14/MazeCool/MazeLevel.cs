﻿using MazeCool.Cells;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MazeCool
{
    public class MazeLevel : IMazeLevel
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Сharacter Hero { get; set; }

        public List<BaseCell> Cells { get; set; }

        public void ReplaceCell(BaseCell cell)
        {
            var oldCell = Cells.Single(c => c.X == cell.X && c.Y == cell.Y);

            Cells.Remove(oldCell);

            Cells.Add(cell);
        }

        public void Move(Direction left)
        {
            Hero.lastDirection = left;
            Hero.MessageInMyHead = "";

            var destinationX = Hero.X;
            var destinationY = Hero.Y;

            switch (left)
            {
                case Direction.Left:
                    destinationX--;
                    break;
                case Direction.Right:
                    destinationX++;
                    break;
                case Direction.Up:
                    destinationY--;
                    break;
                case Direction.Down:
                    destinationY++;
                    break;
                default:
                    break;
            }

            var destinationCell = Cells
                .SingleOrDefault(c =>
                    c.X == destinationX
                     && c.Y == destinationY);
            
            if (destinationCell == null)
            {
                return;
            }

            if (destinationCell.TryToStep(Hero))
            {
                Hero.X = destinationX;
                Hero.Y = destinationY;
            }
        }
    }
}
