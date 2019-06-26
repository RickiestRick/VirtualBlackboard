using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaktionslogik für DragableSheetUserControll.xaml
    /// </summary>
    public partial class DragableSheetUserControll : UserControl
    {
        private bool _isMoving;
        private Point? _buttonPosition;
        private static int index = 55;
        private double deltaX;
        private double deltaY;
        private TranslateTransform _currentTT;
        public static UniformGrid MyGrid;
        public DragableSheetUserControll()
        {
            InitializeComponent();
            index++;
        }

        private void Samplebutton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_buttonPosition == null)
                _buttonPosition = ((UserControl)sender).TransformToAncestor(MyGrid).Transform(new Point(0, 0));
            var mousePosition = Mouse.GetPosition(MyGrid);
            deltaX = mousePosition.X - _buttonPosition.Value.X;
            deltaY = mousePosition.Y - _buttonPosition.Value.Y;
            MyBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(81, 81, 81));
            _isMoving = true;
            Grid.SetZIndex(this, index++);
            Panel.SetZIndex(this, 666);
            UniformGrid.SetZIndex(this, index++);
        }

        private void Samplebutton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _currentTT = ((UserControl)sender).RenderTransform as TranslateTransform;
            _isMoving = false;
            MyBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void Samplebutton_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMoving) return;
            var mousePoint = Mouse.GetPosition(MyGrid);
            var offsetX = (_currentTT == null ? _buttonPosition.Value.X : _buttonPosition.Value.X - _currentTT.X) + deltaX - mousePoint.X;
            var offsetY = (_currentTT == null ? _buttonPosition.Value.Y : _buttonPosition.Value.Y - _currentTT.Y) + deltaY - mousePoint.Y;
            ((UserControl)sender).RenderTransform = new TranslateTransform(-offsetX, -offsetY);

        }


        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            _currentTT = ((UserControl)sender).RenderTransform as TranslateTransform;
            _isMoving = false;
            MyBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }
    }
}
