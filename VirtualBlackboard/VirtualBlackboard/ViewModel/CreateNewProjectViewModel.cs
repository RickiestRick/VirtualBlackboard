using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VirtualBlackboard.Helpers;
using VirtualBlackboard.Model;
using VirtualBlackboard.Services;

namespace VirtualBlackboard.ViewModel
{
  public  class CreateNewProjectViewModel
    {
        private Services.ProjectDataProvider _projectDataProvider;

        public CreateNewProjectViewModel()
        {
            Sheets = new ObservableCollection<Sheet>();
            CreateCommand = new RelayCommand<object>(CreateProject);
            _projectDataProvider = new Services.ProjectDataProvider();
        }

        public ICollection<Sheet> Sheets { get; set; }

        public string ProjectName { get; set; }

        public ICommand CreateCommand { get; set; }

        public void CreateProject(object obj)
        {
            var dia = DialogCoordinator.Instance;

            if(ProjectName == null || ProjectName==string.Empty)
            {
                dia.ShowMessageAsync(this, "Warnung", "Projekt Name darf nicht leer sein!");
                return;
            }
            if(File.Exists(Environment.CurrentDirectory + @"\Projects\" + ProjectName))
            {
                dia.ShowMessageAsync(this, "Warnung", "Projekt bereits vorhanden!");
                return;
            }
            if(Sheets.Any() == false)
            {
                dia.ShowMessageAsync(this, "Warnung", "Mindestens ein Eintrag muss vorhanden sein!");
                return;
            }
            Project proj = new Project();
            proj.DisplayText = ProjectName;
            proj.Filepath = Environment.CurrentDirectory + @"\Projects\" + ProjectName;
            proj.Sheets = Sheets;
            _projectDataProvider.Serialize(proj);
            Messenger.Trigger("LoadWelcomeScreen", null);
        }
    
    }
}
