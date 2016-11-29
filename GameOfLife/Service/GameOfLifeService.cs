using System;
using System.Threading;
using GameOfLife.Model;

namespace GameOfLife.Service
{
    public class GameOfLifeService
    {
        public GameOfLifeService(int gridWith, int gridHeight)
        {
            Reset(new Grid(gridWith, gridHeight));
        }

        public Grid Grid { get; private set; }

        public event EventHandler<EventArgs> GridUpdated = delegate { };

        public event EventHandler<CellUpdatedEventArgs> CellUpdated = delegate { };

        public event EventHandler<EventArgs> Tick = delegate { };

        public event EventHandler<EventArgs> Stopped = delegate { };

        public bool IsRunning { get; private set; }

        public int Ticks { get; private set; }

        public int GridWidth => Grid.Width;

        public int GridHeight => Grid.Height;

        public void Reset(Grid grid)
        {
            if (IsRunning)
            {
                return;
            }
            Grid = grid;
            GridUpdated.Invoke(this, EventArgs.Empty);
        }

        public void Start()
        {
            Ticks = 0;
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
                if (!UpdateCells())
                {
                    IsRunning = false;
                }
                Ticks++;
                Tick.Invoke(this, EventArgs.Empty);
            }
            Stopped.Invoke(this, EventArgs.Empty);
        }

        private bool UpdateCells()
        {
            var anyChanges = false;
            var newGrid = GameEngine.Process(Grid);

            for (var x = 0; x < Grid.Width; x++)
            {
                for (var y = 0; y < Grid.Height; y++)
                {
                    if (Grid[x, y] != newGrid[x, y])
                    {
                        Grid[x, y] = newGrid[x, y];
                        CellUpdated.Invoke(this, new CellUpdatedEventArgs { X = x, Y = y, NewIsAlive = newGrid[x, y] });
                        anyChanges = true;
                    }
                }
            }
            return anyChanges;
        }
    }
}