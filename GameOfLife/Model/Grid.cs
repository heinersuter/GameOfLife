namespace GameOfLife.Model
{
    public class Grid
    {
        private readonly bool[,] _cells;

        public Grid(int width, int height)
        {
            _cells = new bool[width, height];
        }

        public bool this[int x, int y]
        {
            get { return _cells[x, y]; }
            set { _cells[x, y] = value; }
        }

        public int Width => _cells.GetLength(0);

        public int Height => _cells.GetLength(1);
    }
}