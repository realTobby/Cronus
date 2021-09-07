using Cronus.DragableElements;
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

        private UserControl currentMarkedElement;

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

        void Element_MouseMove(object sender, MouseEventArgs mea)
        {
            Point p = mea.GetPosition(canvas);
            if (mea.Source is UserControl uc)
            {
                
                // check where cursor is
               // Console.WriteLine("Element:");
                //Console.WriteLine("X: " + Canvas.GetLeft(uc).ToString() + " / Y: " + Canvas.GetTop(uc).ToString());

                //Console.WriteLine("Maus: ");
               // Console.WriteLine("X: " + p.X + " / Y: " + p.Y);

                // check for corner piece
                Point uc_ul = new Point(Canvas.GetLeft(uc), Canvas.GetTop(uc));
                Point uc_ur = new Point(Canvas.GetLeft(uc) + uc.ActualWidth, Canvas.GetTop(uc));
                Point uc_ll = new Point(Canvas.GetLeft(uc), Canvas.GetTop(uc) + uc.ActualHeight);
                Point uc_lr = new Point(Canvas.GetLeft(uc) + uc.ActualWidth, Canvas.GetTop(uc) + uc.ActualHeight);

                double leanWay = 15;


                if (mea.LeftButton == MouseButtonState.Pressed)
                {
                    Canvas.SetLeft(uc, p.X - uc.ActualWidth / 2);
                    Canvas.SetTop(uc, p.Y - uc.ActualHeight / 2);
                    Canvas.SetZIndex(uc, 10);
                    uc.CaptureMouse();
                    MarkElement(sender, mea);
                }
                else
                {
                    uc.ReleaseMouseCapture();
                    Canvas.SetZIndex(uc, -10);
                }
            }
        }

        private void MarkElement(object sender, RoutedEventArgs e)
        {
            if(e.Source is UserControl uc)
            {
                if(originalViewModel.SelectedUserControl == null)
                {
                    originalViewModel.SelectedUserControl = uc;
                }

                if (originalViewModel.SelectedUserControl != uc)
                {
                    originalViewModel.SelectedUserControl.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                    originalViewModel.SelectedUserControl.BorderThickness = new Thickness(0);
                    originalViewModel.SelectedUserControl = uc;
                }

                originalViewModel.SelectedUserControl.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                originalViewModel.SelectedUserControl.BorderThickness = new Thickness(1);
            }
            else
            {
                originalViewModel.SelectedUserControl.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                originalViewModel.SelectedUserControl.BorderThickness = new Thickness(0);
                originalViewModel.SelectedUserControl = null;
            }
        }

        private void btn_add_element_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_add_rectangle_Click(object sender, RoutedEventArgs e)
        {
            ZPLElementRectangleBox newRectangle = new ZPLElementRectangleBox();
            newRectangle.rectangle.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
            Canvas.SetLeft(newRectangle, 0);
            Canvas.SetTop(newRectangle, 0);
            newRectangle.MouseMove += Element_MouseMove;
            newRectangle.MouseLeftButtonUp += MarkElement;
            canvas.Children.Add(newRectangle);
        }

        private void btn_add_text_Click(object sender, RoutedEventArgs e)
        {
            ZPLElementText newText = new ZPLElementText();
            Canvas.SetLeft(newText, 0);
            Canvas.SetTop(newText, 0);
            newText.MouseMove += Element_MouseMove;
            newText.MouseLeftButtonUp += MarkElement;
            canvas.Children.Add(newText);
        }
    }
}
