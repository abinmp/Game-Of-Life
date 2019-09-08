

namespace Game
{
    public interface IGame
    {
        Cell[,] Build();
        Cell[,] Play();
        Cell[,] GetCells();
    }
}
