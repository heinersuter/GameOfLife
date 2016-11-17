using System.Windows;
using GameOfLife.Commons;
using GameOfLife.View;

namespace GameOfLife
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();

            var dialogService = new DialogService(mainWindow);
            var mainViewModel = new MainViewModel(dialogService);

            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }
    }
}
