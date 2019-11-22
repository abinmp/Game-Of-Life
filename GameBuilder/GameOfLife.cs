using System;

namespace Game
{
    public class GameOfLife : IGame
    {
        uint universeSize;
        Cell[,] board;
        public GameOfLife(uint UniverseSize = 25)
        {
            universeSize = UniverseSize;
            board = new Cell[UniverseSize, UniverseSize];
            SetDefaultValues();
        }

        public Cell[,] GetCells()
        {
            return board;
        }

        public Cell[,] Build()
        {
            Random generator = new Random();

            foreach (var cell in board)
                cell.IsAlive = (generator.Next(2) == 0) ? false : true;

            return board;
        }

        public Cell[,] Play()
        {
            int numNeighbors;

            for (var i = 0; i < universeSize; i++)
            {
                for (var j = 0; j < universeSize; j++)
                {
                    numNeighbors = GetNumOfLiveNeighbors(i, j);

                    if (board[i, j].value == 1 && (numNeighbors < 2 || numNeighbors > 3))
                        board[i, j].value = -1;
                    else if (board[i, j].value == 0 && numNeighbors == 3)
                        board[i, j].value = 2;
                }
            }

            foreach (var cell in board)
            {
                if (cell.value == 2)
                    cell.value = 1;

                if (cell.value == -1)
                    cell.value = 0;
            }
            return board;
        }

        private int GetNumOfLiveNeighbors(int row, int col)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (!(i == 0 && j == 0))
                    {
                        int r = row + i, c = col + j;
                        if (r >= 0 && r < universeSize
                                        && c >= 0 && c < universeSize
                                        && Math.Abs(board[r, c].value) == 1)
                            count++;
                    }
                }
            }
            return count;
        }

        private void SetDefaultValues()
        {
            for (var i = 0; i < universeSize; i++)
            {
                for (var j = 0; j < universeSize; j++)
                {
                    board[i, j] = new Cell(false);
                }
            }
        }
    }
}
