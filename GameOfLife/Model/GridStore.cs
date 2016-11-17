using System.Collections.Generic;

namespace GameOfLife.Model
{
    public class GridStore
    {
        public IDictionary<string, Grid> Grids { get; } = new Dictionary<string, Grid>();
    }
}