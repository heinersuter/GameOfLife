using System;
using System.Threading;
using GameOfLife.Model;

namespace GameOfLife.Service
{
    public class GameOfLifeService
    {
        // TODO: Add tick counter to display it
        // TODO: Stop if no changes in one tick. Add event to notify UI.

        private readonly Grid _grid;

        public GameOfLifeService(int gridWith, int gridHeight)
        {
            _grid = new Grid(gridWith, gridHeight);
        }

        public GameOfLifeService(Grid grid)
        {
            _grid = grid;
        }

        public event EventHandler<CellUpdatedEventArgs> CellUpdated = delegate { };

        public bool IsRunning { get; private set; }

        public int GridWidth => _grid.Width;

        public int GridHeight => _grid.Height;

        public void Start()
        {
            IsRunning = true;
            new Action(Run).BeginInvoke(null, null);
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Toggle(int x, int y)
        {
            _grid[x, y] = !_grid[x, y];
            CellUpdated.Invoke(this, new CellUpdatedEventArgs { X = x, Y = y, NewIsAlive = _grid[x, y] });
        }

        private void Run()
        {
            while (IsRunning)
            {
                Thread.Sleep(500);
                UpdateCells();
            }
        }

        private void UpdateCells()
        {
            var newGrid = GameEngine.Process(_grid);

            for (var x = 0; x < _grid.Width; x++)
            {
                for (var y = 0; y < _grid.Height; y++)
                {
                    if (_grid[x, y] != newGrid[x, y])
                    {
                        _grid[x, y] = newGrid[x, y];
                        CellUpdated.Invoke(this, new CellUpdatedEventArgs { X = x, Y = y, NewIsAlive = newGrid[x, y] });
                    }
                }
            }

        }
    }
}