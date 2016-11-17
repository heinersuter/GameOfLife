using System;
using System.Threading;
using GameOfLife.Model;

namespace GameOfLife.Service
{
    public class GameOfLifeService
    {
        // TODO: Add tick counter to display it
        // TODO: Stop if no changes in one tick. Add event to notify UI.

        public GameOfLifeService(int gridWith, int gridHeight)
        {
            Grid = new Grid(gridWith, gridHeight);
        }

        public Grid Grid { get; }

        public event EventHandler<CellUpdatedEventArgs> CellUpdated = delegate { };

        public bool IsRunning { get; private set; }

        public int GridWidth => Grid.Width;

        public int GridHeight => Grid.Height;

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
            Grid[x, y] = !Grid[x, y];
            CellUpdated.Invoke(this, new CellUpdatedEventArgs { X = x, Y = y, NewIsAlive = Grid[x, y] });
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
            var newGrid = GameEngine.Process(Grid);

            for (var x = 0; x < Grid.Width; x++)
            {
                for (var y = 0; y < Grid.Height; y++)
                {
                    if (Grid[x, y] != newGrid[x, y])
                    {
                        Grid[x, y] = newGrid[x, y];
                        CellUpdated.Invoke(this, new CellUpdatedEventArgs { X = x, Y = y, NewIsAlive = newGrid[x, y] });
                    }
                }
            }

        }
    }
}