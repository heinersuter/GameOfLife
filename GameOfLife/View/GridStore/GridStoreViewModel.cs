using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Commons;
using GameOfLife.Model;
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

        public DelegateCommand CreateCommand => BackingFields.GetCommand(Create, CanCreate);

        public DelegateCommand LoadCommand => BackingFields.GetCommand(Load, CanLoad);

        public DelegateCommand SaveCommand => BackingFields.GetCommand(Save, CanSave);

        public DelegateCommand ClearCommand => BackingFields.GetCommand(Clear, CanClear);

        private bool CanCreate()
        {
            return !_gameService.IsRunning;
        }

        private void Create()
        {
            var dialog = new CreateDialogViewModel { Width = _gameService.GridWidth, Height = _gameService.GridHeight };
            _dialogService.ShowDialog(dialog);
            if (dialog.IsConfirm)
            {
                _gameService.Reset(new Grid(dialog.Width, dialog.Height));
            }
        }

        private bool CanLoad()
        {
            return !_gameService.IsRunning;
        }

        private void Load()
        {
            var dialog = new LoadDialogViewModel { Names = _gridStoreService.GetNames() };
            _dialogService.ShowDialog(dialog);
            if (dialog.IsConfirm)
            {
                _gameService.Reset(_gridStoreService.Load(dialog.SelectedName));
            }
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

        private bool CanClear()
        {
            return !_gameService.IsRunning;
        }

        private void Clear()
        {
            var width = _gameService.GridWidth;
            var height = _gameService.GridHeight;
            _gameService.Reset(new Grid(width, height));
        }
    }
}