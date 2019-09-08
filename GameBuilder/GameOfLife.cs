using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game
{
    public class GameOfLife : IGame
    {
        uint universeSize;
        Cell[,] cells;
        public GameOfLife(uint UniverseSize = 25)
        {
            universeSize = UniverseSize;
            cells = new Cell[UniverseSize, UniverseSize];
            SetDefaultValues();
        }

        public Cell[,] GetCells()
        {
            return cells;
        }

        public Cell[,] Build()
        {
            //TODO: Refactor it to draw the canvas initially for verious methods
            Random generator = new Random();

            for (var i = 0; i < universeSize; i++)
            {
                for (var j = 0; j < universeSize; j++)
                {
                    cells[i, j] = new Cell(i, j, ((generator.Next(2) == 0) ? false : true));
                }
            }
            return cells;
        }

        public Cell[,] Play()
        {
            int numNeighbors;
            var changedCells = new List<Cell>();

            for (var i = 0; i < universeSize; i++)
            {
                for (var j = 0; j < universeSize; j++)
                {
                    numNeighbors = GetNeighbors(i, j);

                    if (cells[i, j].IsAlive && numNeighbors < 2 || numNeighbors > 3)
                        changedCells.Add(new Cell(i, j, false));
                    else if (!cells[i, j].IsAlive && numNeighbors == 3)
                        changedCells.Add(new Cell(i, j, true));
                }
            }

            Parallel.ForEach(changedCells, (cell) =>
            {
                cells[cell.Row, cell.Column].IsAlive = cell.IsAlive;
            });

            return cells;
        }

        private int GetNeighbors(int x, int y)
        {
            var total = 0;
            if (y > 0)
                total += cells[x, y - 1].IsAlive ? 1 : 0;
            if (y < universeSize - 1)
                total += cells[x, y + 1].IsAlive ? 1 : 0;
            if (x > 0)
                total += cells[x - 1, y].IsAlive ? 1 : 0;
            if (x < universeSize - 1)
                total += cells[x + 1, y].IsAlive ? 1 : 0;
            if (y > 0 && x > 0)
                total += cells[x - 1, y - 1].IsAlive ? 1 : 0;
            if (y > 0 && x < universeSize - 1)
                total += cells[x + 1, y - 1].IsAlive ? 1 : 0;
            if (y < universeSize - 1 && x > 0)
                total += cells[x - 1, y + 1].IsAlive ? 1 : 0;
            if (y < universeSize - 1 && x < universeSize - 1)
                total += cells[x + 1, y + 1].IsAlive ? 1 : 0;
            return total;
        }

        private void SetDefaultValues()
        {
            for (var i = 0; i < universeSize; i++)
            {
                for (var j = 0; j < universeSize; j++)
                {
                    cells[i, j] = new Cell(i, j, false );
                }
            }
        }
    }
}
