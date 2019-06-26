using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VirtualBlackboard.Helpers;
using VirtualBlackboard.Model;
using VirtualBlackboard.Services;

namespace VirtualBlackboard.ViewModel
{
    public class WelcomeScreenViewModel : ViewModelBase
    {
        private ProjectDataProvider _sheetDataProviderService;
        public ICollection<Project> AllSheetCollections { get; }

        public ICommand DoubleClickCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        public WelcomeScreenViewModel()
        {
            AllSheetCollections = new ObservableCollection<Project>();
            _sheetDataProviderService = new ProjectDataProvider();
            var sheets=_sheetDataProviderService.GetAllSheets();
            sheets.ToList().ForEach(x => AllSheetCollections.Add(x));
            DoubleClickCommand = new RelayCommand<Project>(DoubleClick);
            DeleteCommand = new RelayCommand<Project>(Delete);

            //the last Entry :)
            AllSheetCollections.Add(new Project() { DisplayText = Properties.Resources.New_Project });


        }

        private void Delete(Project obj)
        {
            _sheetDataProviderService.Delete(obj);
            var sheets = _sheetDataProviderService.GetAllSheets();
            AllSheetCollections.Clear();
            sheets.ToList().ForEach(x => AllSheetCollections.Add(x));

            AllSheetCollections.Add(new Project() { DisplayText = Properties.Resources.New_Project });
        }

        private void DoubleClick(Project obj)
        {
            if(obj.DisplayText == Properties.Resources.New_Project)
            {
                Messenger.Trigger("LoadCreateNewProject",null);
            }
            else
            Messenger.Trigger("LoadBlackboard", obj.Sheets);
        }
    }
}
