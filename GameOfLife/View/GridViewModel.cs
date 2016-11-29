using System.Collections.ObjectModel;
using Alsolos.Commons.Wpf.Mvvm;
using GameOfLife.Service;

namespace GameOfLife.View
{
    public class GridViewModel : ViewModel
    {
        private readonly GameOfLifeService _service;

        public GridViewModel(GameOfLifeService service)
        {
            _service = service;
            _service.GridUpdated += (e, args) => { OnGridUpdated(); };
            OnGridUpdated();
        }

        private void OnGridUpdated()
        {
            foreach (var cellViewModel in Cells)
            {
                cellViewModel.Dispose();
            }

            Columns = _service.GridWidth;
            for (var x = 0; x < _service.GridWidth; x++)
            {
                for (var y = 0; y < _service.GridHeight; y++)
                {
                    Cells.Add(new CellViewModel(x, y, _service));
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