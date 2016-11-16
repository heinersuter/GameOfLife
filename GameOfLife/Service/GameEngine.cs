using System.Collections.Generic;
using System.Linq;
using GameOfLife.Model;

namespace GameOfLife.Service
{
    public static class GameEngine
    {
        public static Grid Process(Grid grid)
        {
            var resultGrid = new Grid(grid.Width, grid.Height);

            for (var x = 0; x < grid.Width; x++)
            {
                for (var y = 0; y < grid.Height; y++)
                {
                    var cellIsAlive = grid[x, y];
                    var neighboursAliveCount = GetNeighbours(grid, x, y).Count(neighbour => neighbour);
                    if (cellIsAlive)
                    {
                        if (neighboursAliveCount < 2)
                        {
                            resultGrid[x, y] = false;
                        }
                        else if (neighboursAliveCount > 3)
                        {
                            resultGrid[x, y] = false;
                        }
                        else
                        {
                            resultGrid[x, y] = true;
                        }
                    }
                    else
                    {
                        if (neighboursAliveCount == 3)
                        {
                            resultGrid[x, y] = true;
                        }
                    }
                }
            }

            return resultGrid;
        }

        private static IEnumerable<bool> GetNeighbours(Grid grid, int x, int y)
        {
            var neighbours = new List<bool>();
            if (x > 0)
            {
                neighbours.Add(grid[x - 1, y]);
                if (y > 0)
                {
                    neighbours.Add(grid[x - 1, y - 1]);
                }
                if (y < grid.Height - 1)
                {
                    neighbours.Add(grid[x - 1, y + 1]);
                }
            }
            if (y > 0)
            {
                neighbours.Add(grid[x, y - 1]);
            }
            if (y < grid.Height - 1)
            {
                neighbours.Add(grid[x, y + 1]);
            }
            if (x < grid.Width - 1)
            {
                neighbours.Add(grid[x + 1, y]);
                if (y > 0)
                {
                    neighbours.Add(grid[x + 1, y - 1]);
                }
                if (y < grid.Height - 1)
                {
                    neighbours.Add(grid[x + 1, y + 1]);
                }
            }
            return neighbours;
        }
    }
}