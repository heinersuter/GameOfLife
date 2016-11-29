using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Commons;

namespace GameOfLife.View.GridStore
{
    public class CreateDialogViewModel : DialogViewModel
    {
        public bool IsConfirm { get; private set; }

        public int Width
        {
            get { return BackingFields.GetValue<int>(); }
            set { BackingFields.SetValue(value); }
        }

        public int Height
        {
            get { return BackingFields.GetValue<int>(); }
            set { BackingFields.SetValue(value); }
        }

        public DelegateCommand CreateCommand => BackingFields.GetCommand(Create);

        public DelegateCommand CancelCommand => BackingFields.GetCommand(Cancel);

        private void Create()
        {
            IsConfirm = true;
            Close();
        }

        private void Cancel()
        {
            Close();
        }
    }
}