using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirtualBlackboard.Views
{
    /// <summary>
    /// Interaktionslogik für WelcomeScreenUserControl.xaml
    /// </summary>
    public partial class WelcomeScreenUserControl : UserControl
    {
        public WelcomeScreenUserControl()
        {
            InitializeComponent();
        }

        private void MenuItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

            var grid = sender as Grid;
            var cont = grid.ContextMenu;
            var proj = (cont.Items[0] as MenuItem).CommandParameter;
            (cont.Items[0] as MenuItem).DataContext = WelcomeScreenUC.DataContext;
            (cont.Items[0] as MenuItem).CommandParameter = grid.DataContext;
        }
    }
}
