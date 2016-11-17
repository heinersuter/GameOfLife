using System;
using System.Windows;

namespace GameOfLife.Commons
{
    public partial class DialogWindow
    {
        public DialogWindow()
        {
            InitializeComponent();

            DialogPresenter.DataContextChanged += OnDataContextChanged;
            Closed += OnClosed;
        }

        private void OnClosed(object sender, EventArgs e)
        {
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = e.NewValue as DialogViewModel;

            if (viewModel == null)
            {
                return;
            }

            viewModel.RequestClose += CloseWindow; ;
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }
    }
}
