using System.Windows;

namespace GameOfLife.Commons
{
    public class DialogService
    {
        private readonly Window _parentWindow;

        public DialogService(Window parentWindow)
        {
            _parentWindow = parentWindow;
        }

        public bool? ShowDialog(DialogViewModel viewModel)
        {
            var window = new DialogWindow
            {
                Owner = _parentWindow,
                DataContext = viewModel
            };

            return window.ShowDialog();
        }
    }
}