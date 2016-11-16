using System.Windows;
using GameOfLife.View;

namespace GameOfLife
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainViewModel = new MainViewModel();
            var mainView = new MainView { DataContext = mainViewModel };
            mainView.Show();
        }
    }
}
