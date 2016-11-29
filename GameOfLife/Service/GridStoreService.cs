using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameOfLife.Model;
using Newtonsoft.Json;

namespace GameOfLife.Service
{
    public class GridStoreService
    {
        private const string StoreDirectoryName = @"gameOfLifeStore";

        private IEnumerable<string> _gameNames;
        private readonly JsonSerializerSettings _settings;

        public GridStoreService()
        {
            _settings = new JsonSerializerSettings();
            _settings.Converters.Add(new GridConverter());
            _settings.Formatting = Formatting.Indented;

            Directory.CreateDirectory(StoreDirectoryName);
            _gameNames = Directory.EnumerateFiles(StoreDirectoryName, "*.json").Select(Path.GetFileNameWithoutExtension);
        }

        public IEnumerable<string> GetNames()
        {
            return _gameNames;
        }

        public void Save(Grid grid, string name)
        {
            var fileName = Path.Combine(StoreDirectoryName, name + ".json");
            File.WriteAllText(fileName, JsonConvert.SerializeObject(grid, _settings));
        }

        public Grid Load(string name)
        {
            var fileName = Path.Combine(StoreDirectoryName, name + ".json");
            return JsonConvert.DeserializeObject<Grid>(File.ReadAllText(fileName), _settings);
        }
    }
}