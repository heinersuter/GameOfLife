using System;
using System.Collections.ObjectModel;
using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Service;

namespace GameOfLife.View
{
    public class GridViewModel : ViewModel
    {
        public GridViewModel(GameOfLifeService service)
        {
            Columns = service.GridWidth;
            for (var x = 0; x < service.GridWidth; x++)
            {
                for (var y = 0; y < service.GridHeight; y++)
                {
                    Cells.Add(new CellViewModel(x, y, service));
                }
            }
        }

        public ObservableCollection<CellViewModel> Cells { get; } = new ObservableCollection<CellViewModel>();

        public int Columns
        {
            get { return BackingFields.GetValue<int>(); }
            set { BackingFields.SetValue(value); }
        }
    }
}