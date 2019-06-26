using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using VirtualBlackboard.Helpers;
using VirtualBlackboard.Model;
using VirtualBlackboard.Services;
using VirtualBlackboard.Views;

namespace VirtualBlackboard.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand HomeCommand { get; set; }
        public UserControl ActualContent { get; set; }

        public MainViewModel()
        {
            Messenger.Register("LoadWelcomeScreen", LoadWelcomeScreen);
            Messenger.Register("LoadCreateNewProject", LoadCreateNewProject);
            Messenger.Register("LoadBlackboard", LoadBlackboard);
            HomeCommand = new RelayCommand<object>(x => LoadWelcomeScreen(x));
            ActualContent = new WelcomeScreenUserControl();

        }

        private void LoadBlackboard(object obj)
        {
            var b = new MainBlackboard();
            b.DataContext = new MainBlackboardViewModel(obj as ICollection<Sheet>);
            ActualContent = b;
            RaisePropertyChanged("ActualContent");
        }

        private void LoadCreateNewProject(object obj)
        {
            ActualContent = new CreateNewProjectUserControll();
            RaisePropertyChanged("ActualContent");
        }

        private void LoadWelcomeScreen(object obj)
        {
            ActualContent = new WelcomeScreenUserControl();
            RaisePropertyChanged("ActualContent");
        }



    }
}
