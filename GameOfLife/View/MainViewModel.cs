using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Commons;
using GameOfLife.Service;

namespace GameOfLife.View
{
    public class MainViewModel : ViewModel
    {
        private readonly GameOfLifeService _gameService;

        public MainViewModel(DialogService dialogService)
        {
            _gameService = new GameOfLifeService(20, 20);

            GridStore = new GridStoreViewModel(_gameService, dialogService);
            Grid = new GridViewModel(_gameService);
        }

        public GridStoreViewModel GridStore
        {
            get { return BackingFields.GetValue<GridStoreViewModel>(); }
            set { BackingFields.SetValue(value); }
        }

        public GridViewModel Grid
        {
            get { return BackingFields.GetValue<GridViewModel>(); }
            set { BackingFields.SetValue(value); }
        }

        public DelegateCommand StartCommand => BackingFields.GetCommand(Start, CanStart);

        public DelegateCommand StopCommand => BackingFields.GetCommand(Stop, CanStop);

        private bool CanStart()
        {
            return !_gameService.IsRunning;
        }

        private void Start()
        {
            _gameService.Start();
        }

        private bool CanStop()
        {
            return _gameService.IsRunning;
        }

        private void Stop()
        {
            _gameService.Stop();
        }
    }
}