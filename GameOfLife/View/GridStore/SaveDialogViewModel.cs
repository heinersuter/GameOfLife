using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Commons;

namespace GameOfLife.View.GridStore
{
    public class SaveDialogViewModel : DialogViewModel
    {
        public string Name
        {
            get { return BackingFields.GetValue<string>(); }
            set { BackingFields.SetValue(value); }
        }

        public DelegateCommand SaveCommand => BackingFields.GetCommand(Save);

        public DelegateCommand CancelCommand => BackingFields.GetCommand(Cancel);

        public bool IsConfirm { get; private set; }

        private void Save()
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