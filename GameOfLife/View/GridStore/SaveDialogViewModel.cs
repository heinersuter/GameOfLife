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

        public DelegateCommand SaveCommand => BackingFields.GetCommand(Save, CanSave);

        public DelegateCommand CancelCommand => BackingFields.GetCommand(Cancel, CanCancel);

        public bool IsConfirm { get; private set; }

        private bool CanSave()
        {
            return true;
        }

        private void Save()
        {
            IsConfirm = true;
            Close();
        }

        private bool CanCancel()
        {
            return true;
        }

        private void Cancel()
        {
            Close();
        }
    }
}