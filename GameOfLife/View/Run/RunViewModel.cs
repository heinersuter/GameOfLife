using System.Windows.Input;
using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Service;

namespace GameOfLife.View.Run
{
    public class RunViewModel : ViewModel
    {
        private readonly GameOfLifeService _gameService;

        public RunViewModel(GameOfLifeService gameService)
        {
            _gameService = gameService;
            _gameService.Tick += (sender, args) => { Ticks = _gameService.Ticks; };
            _gameService.Stopped += (sender, args) =>
            {
                StartCommand.RaiseCanExecuteChanged();
            };
        }

        public DelegateCommand StartCommand => BackingFields.GetCommand(Start, CanStart);

        public DelegateCommand StopCommand => BackingFields.GetCommand(Stop, CanStop);

        public int Ticks
        {
            get { return BackingFields.GetValue<int>(); }
            private set { BackingFields.SetValue(value); }
        }

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