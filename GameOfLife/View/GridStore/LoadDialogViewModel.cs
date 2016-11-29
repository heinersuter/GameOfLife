using System.Collections.Generic;
using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Commons;

namespace GameOfLife.View.GridStore
{
    public class LoadDialogViewModel : DialogViewModel
    {
        public bool IsConfirm { get; private set; }

        public IEnumerable<string> Names
        {
            get { return BackingFields.GetValue<IEnumerable<string>>(); }
            set { BackingFields.SetValue(value); }
        }

        public string SelectedName
        {
            get { return BackingFields.GetValue<string>(); }
            set { BackingFields.SetValue(value); }
        }

        public DelegateCommand LoadCommand => BackingFields.GetCommand(Load);

        public DelegateCommand CancelCommand => BackingFields.GetCommand(Cancel);


        private void Load()
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