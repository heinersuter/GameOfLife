using System;
using Alsolos.Commons.Wpf.Mvvm;

namespace GameOfLife.Commons
{
    public class DialogViewModel : ViewModel
    {
        public event EventHandler<EventArgs> RequestClose = delegate { };

        public string Title
        {
            get { return BackingFields.GetValue<string>(); }
            set { BackingFields.SetValue(value); }
        }

        protected void Close()
        {
            RequestClose.Invoke(this, EventArgs.Empty);
        }
    }
}