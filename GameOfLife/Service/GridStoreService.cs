using GameOfLife.Model;

namespace GameOfLife.Service
{
    public class GridStoreService
    {
        public void Save(Grid grid, string name)
        {
        }

        public Grid Load(string name)
        {
            return new Grid(20, 20);
        }
    }
}