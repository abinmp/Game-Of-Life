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
        public Cell(int row, int column, bool alive)
        {
            Row = row;
            Column = column;
            this.alive = alive;
        }
        /// <summary>
        /// Gets the row index 
        /// </summary>
        public int Row { get; private set; }

        /// <summary>
        /// Gets the column index 
        /// </summary>
        public int Column { get; private set; }
       
        private bool alive;

        /// <summary>
        /// Value for cell is alive or dead.
        /// </summary>
        public bool IsAlive
        {
            get => alive; set => alive = value;
        }
    }
}
