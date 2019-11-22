namespace Game
{
    public class Cell
    {
        /// <summary>
        /// Initialises a new instance of a Cell.
        /// </summary>
        /// <param name="row">Row index </param>
        /// <param name="column">Column index</param>
        /// <param name="alive">Is alive or not</param>
        public Cell(bool alive)
        {
            value = alive ? 1 : 0;
        }

        protected internal int value;

        /// <summary>
        /// Value for cell is alive or dead.
        /// </summary>
        public bool IsAlive
        {
            get => value == 1; set => this.value = value ? 1 : 0;
        }
    }
}
