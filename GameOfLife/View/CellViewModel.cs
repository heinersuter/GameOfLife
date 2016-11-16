using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Service;

namespace GameOfLife.View
{
    public class CellViewModel : ViewModel
    {
        private readonly int _x;
        private readonly int _y;
        private readonly GameOfLifeService _service;

        public CellViewModel(int x, int y, GameOfLifeService service)
        {
            _x = x;
            _y = y;
            _service = service;

            service.CellUpdated += OnCellUpdated;
        }

        public bool IsAlive
        {
            get { return BackingFields.GetValue<bool>(); }
            set { BackingFields.SetValue(value); }
        }

        public DelegateCommand ToggleCommand => BackingFields.GetCommand(Toggle, CanToggle);

        private bool CanToggle()
        {
            return !_service.IsRunning;
        }

        private void Toggle()
        {
            _service.Toggle(_x, _y);
        }

        private void OnCellUpdated(object sender, CellUpdatedEventArgs e)
        {
            if (e.X == _x && e.Y == _y)
            {
                IsAlive = e.NewIsAlive;
            }
        }
    }
}