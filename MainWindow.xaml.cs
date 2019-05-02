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

namespace TestingWallsAndPlayers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //global variables
        public System.Windows.Threading.DispatcherTimer gameTimer;
        double d = 5;
        int i = 0;
        int speed = 5;
        Point position = new Point();
        Rectangle car = new Rectangle();
        Rectangle Wall = new Rectangle();

        public MainWindow()
        {

            InitializeComponent();

            //start Timer
            gameTimer = new System.Windows.Threading.DispatcherTimer();
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            gameTimer.Start();
            Point centre = new Point();
            car.Width = 50;
            car.Height = 50;
            car.Fill = Brushes.Aqua;
            Wall.Width = 50;
            Wall.Height = 300;
            Wall.Fill = Brushes.Black;
            Track.Children.Add(car);
            position.X = 0;
            position.Y = 0;
            Canvas.SetLeft(car, position.X);
            Canvas.SetTop(car, position.Y);
            car.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Down))
            {

                position.Y += 10;
                Canvas.SetTop(car, position.Y);
                
            
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                position.Y -= 10;
                Canvas.SetTop(car, position.Y);
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                car.RenderTransform = new RotateTransform()
                { Angle = i };
                i += 10;

            }

            }
    }
        
}
