using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Commons;
using GameOfLife.Service;

namespace GameOfLife.View.GridStore
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
            var dialog = new SaveDialogViewModel();
            _dialogService.ShowDialog(dialog);
            if (dialog.IsConfirm)
            {
                _gridStoreService.Save(_gameService.Grid, dialog.Name);
            }
        }
    }
}