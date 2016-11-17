using System.Collections.Generic;
using System.IO;
using GameOfLife.Model;
using Newtonsoft.Json;

namespace GameOfLife.Service
{
    public class GridStoreService
    {
        private const string StoreFileName = @"gameOfLifeStore.json";
        private readonly GridStore _store;
        private readonly JsonSerializerSettings _settings;

        public GridStoreService()
        {
            _settings = new JsonSerializerSettings();
            _settings.Converters.Add(new GridConverter());
            _settings.Formatting = Formatting.Indented;

            if (File.Exists(StoreFileName))
            {
                _store = JsonConvert.DeserializeObject<GridStore>(File.ReadAllText(StoreFileName), _settings);
            }
            else
            {
                _store = new GridStore();
            }
        }

        public IEnumerable<string> GetNames()
        {
            return _store.Grids.Keys;
        }

        public void Save(Grid grid, string name)
        {
            if (_store.Grids.Keys.Contains(name))
            {
                _store.Grids[name] = grid;
            }
            else
            {
                _store.Grids.Add(name, grid);
            }
            File.WriteAllText(StoreFileName, JsonConvert.SerializeObject(_store, _settings));
        }

        public Grid Load(string name)
        {
            return _store.Grids[name];
        }
    }
}