using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Service;

namespace GameOfLife.View
{
    public class MainViewModel : ViewModel
    {
        private readonly GameOfLifeService _service;

        public MainViewModel()
        {
            _service = new GameOfLifeService(20, 20);

            Grid = new GridViewModel(_service);
        }

        public GridViewModel Grid
        {
            get { return BackingFields.GetValue<GridViewModel>(); }
            set { BackingFields.SetValue(value); }
        }

        public DelegateCommand StartCommand => BackingFields.GetCommand(ExecuteStart, CanExecuteStart);

        public DelegateCommand StopCommand => BackingFields.GetCommand(ExecuteStop, CanExecuteStop);

        private bool CanExecuteStart()
        {
            return !_service.IsRunning;
        }

        private void ExecuteStart()
        {
            _service.Start();
        }

        private bool CanExecuteStop()
        {
            return _service.IsRunning;
        }

        private void ExecuteStop()
        {
            _service.Stop();
        }
    }
}