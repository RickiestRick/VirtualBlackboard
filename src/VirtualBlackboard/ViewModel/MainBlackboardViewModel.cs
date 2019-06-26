using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VirtualBlackboard.Helpers;
using VirtualBlackboard.Model;

namespace VirtualBlackboard.ViewModel
{
    public class MainBlackboardViewModel : ViewModelBase
    {

        public ICommand RefreshCommand { get; set; }

        public MainBlackboardViewModel(ICollection<Sheet> sheetCollection)
        {
            SheetCollection = new ObservableCollection<Sheet>();
            sheetCollection.ToList().ForEach(x => SheetCollection.Add(x));
            RefreshCommand = new RelayCommand<object>(Refresh);
        }

        private void Refresh(object obj)
        {
            var l = new List<Sheet>();
            SheetCollection.ToList().ForEach(x => l.Add(x));
            SheetCollection.Clear();
            l.ToList().ForEach(x => SheetCollection.Add(x));
            RaisePropertyChanged("SheetCollection");
        }

        public ObservableCollection<Sheet> SheetCollection { get; }
    }
}
