using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Commons;
using GameOfLife.Service;
using GameOfLife.View.GridStore;

namespace GameOfLife.View
{
    public class GridStoreViewModel : ViewModel
    {
        private readonly GameOfLifeService _gameService;
        private readonly DialogService _dialogService;
        private readonly GridStoreService _gridStoreService;

        public GridStoreViewModel(GameOfLifeService gameService, DialogService dialogService)
        {
            _gameService = gameService;
            _dialogService = dialogService;
            _gridStoreService = new GridStoreService();
        }

        public DelegateCommand LoadCommand => BackingFields.GetCommand(Load, CanLoad);

        public DelegateCommand SaveCommand => BackingFields.GetCommand(Save, CanSave);

        private bool CanLoad()
        {
            return !_gameService.IsRunning;
        }

        private void Load()
        {
            _gridStoreService.Load("s");
        }

        private bool CanSave()
        {
            return !_gameService.IsRunning;
        }

        private void Save()
        {
            _dialogService.ShowDialog(new SaveDialogViewModel());
            _gridStoreService.Save(_gameService.Grid, "s");
        }
    }
}