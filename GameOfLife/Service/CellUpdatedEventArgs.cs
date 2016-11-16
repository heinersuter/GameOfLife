using System;

namespace GameOfLife.Service
{
    public class CellUpdatedEventArgs : EventArgs
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool NewIsAlive { get; set; }
    }
}