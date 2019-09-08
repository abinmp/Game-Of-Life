
namespace Game
{
    public interface IGameBuilder
    {
        /// <summary>
        /// Build Game
        /// </summary>
        /// <returns></returns>
        Cell[,] BuildGame();

        /// <summary>
        /// Play Game
        /// </summary>
        /// <returns></returns>
        Cell[,] Play();

        /// <summary>
        /// Number of play so far
        /// </summary>
        int NumberOfPlay { get; }

        /// <summary>
        /// Get Cells
        /// </summary>
        /// <returns></returns>
        Cell[,] GetCells();
    }
}
