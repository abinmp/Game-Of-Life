using Game;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfGameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly uint UniverseSize;
        Cell[,] cells;
        IGameBuilder gameBuilder;

        public MainWindow()
        {
            InitializeComponent();

            //TODO: Get UniverseSize from config or UI and draw/resize the canvas
            UniverseSize = 25;

            //TODO: Use dependency injection
            gameBuilder = new GameBuilder(new GameOfLife(UniverseSize));
            BuildAndDraw();
        }

        private void BuildAndDraw()
        {
            cells = gameBuilder.BuildGame();

            if (cells != null && cells.Length > 0)
                Draw();
        }

        private void Draw()
        {
            grid.Children.Clear();
            for (var i = 0; i < 900; i += 36)
            {
                for (var j = 0; j < 900; j += 36)
                {
                    var cell = new Rectangle();
                    cell.Stroke = Brushes.Gray;
                    cell.Fill = cells[i / 36, j / 36].IsAlive ? Brushes.Black : Brushes.White;
                    cell.Height = 36;
                    cell.Width = 36;
                    grid.Children.Add(cell);
                    Canvas.SetTop(cell, i);
                    Canvas.SetLeft(cell, j);
                }
            }
            Generation.Content = "Generation#: " + gameBuilder.NumberOfPlay;
        }      

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            cells = gameBuilder.Play();

            if (cells != null && cells.Length > 0)
                Draw();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            BuildAndDraw();
        }
    }
}
