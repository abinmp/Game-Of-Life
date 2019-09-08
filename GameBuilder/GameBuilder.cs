
namespace Game
{
    public class GameBuilder : IGameBuilder
    {
        private readonly IGame game;
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="game"></param>
        public GameBuilder(IGame game)
        {
            this.game = game;
            NumberOfPlay = 0;           
        }
        /// <summary>
        /// Build Game
        /// </summary>
        /// <returns></returns>
        public Cell[,] BuildGame()
        {
            NumberOfPlay = 0;
            return game.Build();
        }

        /// <summary>
        /// Play Game
        /// </summary>
        /// <returns></returns>
        public Cell[,] Play()
        {
            NumberOfPlay++;
            return game.Play();
        }

        /// <summary>
        /// Number of play so far
        /// </summary>
        public int NumberOfPlay { get; private set; }

        /// <summary>
        /// Get Cells
        /// </summary>
        /// <returns></returns>
        public Cell[,] GetCells()
        {
            return game.GetCells();
        }
    }
}
