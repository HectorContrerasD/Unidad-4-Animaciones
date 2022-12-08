using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Elipses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cvElipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Random r = new Random();
            Point posicion = e.GetPosition(cvElipse);
             elipse = new Ellipse
            {
                Width = 30,
                Height = 30,
                Fill = new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256)))
            };
            cvElipse.Children.Add(elipse);
            Canvas.SetLeft(elipse,posicion.X);
            Canvas.SetTop(elipse, posicion.Y);

            DoubleAnimation animation = new DoubleAnimation
            {
                To = cvElipse.ActualHeight - elipse.Height,
                BeginTime = TimeSpan.FromSeconds(0),
                Duration = TimeSpan.FromSeconds(2),
                EasingFunction = new BounceEase
                {
                    Bounces = 5,
                    EasingMode = EasingMode.EaseOut
                }
            };
            elipse.BeginAnimation(Canvas.TopProperty, animation);
        }
        Ellipse elipse;
        private void cvElipse_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (elipse!=null)
            {


                if (e.HeightChanged && cvElipse.ActualHeight > e.PreviousSize.Height)
                {
                    DoubleAnimation animation = new DoubleAnimation
                    {
                        To = cvElipse.ActualHeight - elipse.Height,
                        BeginTime = TimeSpan.FromSeconds(0),
                        Duration = TimeSpan.FromSeconds(1),
                        EasingFunction = new BounceEase
                        {
                            Bounces = 5,
                            EasingMode = EasingMode.EaseOut
                        }

                    };
                    foreach (var item in cvElipse.Children)
                    {
                        if (item is Ellipse)
                        {
                            ((Ellipse)item).BeginAnimation(Canvas.TopProperty, animation);
                        }
                    }
                }
                if (e.HeightChanged && cvElipse.ActualHeight < e.PreviousSize.Height)
                {
                    DoubleAnimation animation = new DoubleAnimation
                    {
                        To = cvElipse.ActualHeight - elipse.Height,
                        BeginTime = TimeSpan.FromSeconds(0),
                        Duration = TimeSpan.FromSeconds(0),
                       

                    };
                    foreach (var item in cvElipse.Children)
                    {
                        if (item is Ellipse)
                        {
                            ((Ellipse)item).BeginAnimation(Canvas.TopProperty, animation);
                        }
                    }
                }
                if (e.HeightChanged && cvElipse.ActualWidth < e.PreviousSize.Width)
                {
                    DoubleAnimation animation = new DoubleAnimation
                    {
                        To = cvElipse.ActualWidth - elipse.Width,
                        BeginTime = TimeSpan.FromSeconds(0),
                        Duration = TimeSpan.FromSeconds(0),
                        

                    };
                    foreach (var item in cvElipse.Children)
                    {
                        if (item is Ellipse)
                        {
                            ((Ellipse)item).BeginAnimation(Canvas.TopProperty, animation);
                        }
                    }
                }
            }
        }
    }
}
