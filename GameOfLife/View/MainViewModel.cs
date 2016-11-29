using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Commons;
using GameOfLife.Service;
using GameOfLife.View.GridStore;
using GameOfLife.View.Run;

namespace GameOfLife.View
{
    public class MainViewModel : ViewModel
    {
        private readonly GameOfLifeService _gameService;

        public MainViewModel(DialogService dialogService)
        {
            _gameService = new GameOfLifeService(20, 20);
            _gameService.GridUpdated += (e, args) => { UpdateGrid(); };

            RunViewModel = new RunViewModel(_gameService);

            GridStoreViewModel = new GridStoreViewModel(_gameService, dialogService);
            UpdateGrid();
        }

        public GridStoreViewModel GridStoreViewModel
        {
            get { return BackingFields.GetValue<GridStoreViewModel>(); }
            private set { BackingFields.SetValue(value); }
        }

        public RunViewModel RunViewModel
        {
            get { return BackingFields.GetValue<RunViewModel>(); }
            private set { BackingFields.SetValue(value); }
        }

        public GridViewModel GridViewModel
        {
            get { return BackingFields.GetValue<GridViewModel>(); }
            private set { BackingFields.SetValue(value); }
        }

        private void UpdateGrid()
        {
            GridViewModel = new GridViewModel(_gameService);
        }
    }
}