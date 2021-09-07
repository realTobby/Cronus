using Cronus.DraggableControls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Cronus
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ViewModels.ViewModel originalViewModel;

        Random rnd;

        public MainWindow()
        {
            originalViewModel = new ViewModels.ViewModel();
            rnd = new Random();
            InitializeComponent();
#if DEBUG
            originalViewModel.VersionTitle = "Cronus v0.0 [DEV]";
#elif DEBUG
            originalViewModel.VersionTitle = "Cronus v0.0 [RELEASE]";      
#endif

        }

        void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Source is Shape shape)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point p = e.GetPosition(canvas);
                    Canvas.SetLeft(shape, p.X - shape.ActualWidth / 2);
                    Canvas.SetTop(shape, p.Y - shape.ActualHeight / 2);
                    Canvas.SetZIndex(shape, 10);
                    shape.CaptureMouse();
                }
                else
                {
                    shape.ReleaseMouseCapture();
                    Canvas.SetZIndex(shape, -10);
                }
            }
        }

        private void btn_add_element_Click(object sender, RoutedEventArgs e)
        {

            Rectangle newRectangle = new Rectangle();
            //Width = '50' Height = '50' Fill = 'LightPink' Canvas.Left = '350' Canvas.Top = '175'
            newRectangle.Width = 50;
            newRectangle.Height = 50;
            newRectangle.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0,255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
            Canvas.SetLeft(newRectangle, 350);
            Canvas.SetTop(newRectangle, 175);
            newRectangle.MouseMove += Rectangle_MouseMove;
            canvas.Children.Add(newRectangle);
        }
    }
}
