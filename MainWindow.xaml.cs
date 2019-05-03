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
        double speed = 5;
        Point position = new Point();
        Point wallposition1 = new Point();
        Point wallposition2 = new Point();
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
            wallposition1.Y = 150;
            wallposition1.X = 0;
            wallposition2.Y = 200;
            car.Width = 50;
            car.Height = 50;
            car.Fill = Brushes.Aqua;
            Wall.Width = 300;
            Wall.Height = 50;
            Wall.Fill = Brushes.Black;
            Track.Children.Add(Wall);
            Track.Children.Add(car);
            position.X = 100;
            position.Y = 100;
            Canvas.SetLeft(car, position.X);
            Canvas.SetTop(car, position.Y);
            Canvas.SetTop(Wall, 200);
            car.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Down))
            {

                position.Y += speed * 1;
                Canvas.SetTop(car, position.Y);
                if (position.Y >= wallposition1.Y && position.Y <= wallposition2.Y)
                {
                    speed = 0.5;
                    if (position.Y == wallposition2.Y)
                {
                    speed = 0;
                    position.Y -= 10;
                    Canvas.SetTop(car, position.Y);
                    
                }
                }
                
                else
                {
                    speed = 5;
                }

            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                position.Y -= speed * 1;
                Canvas.SetTop(car, position.Y);
                if (position.Y <= wallposition2.Y && position.Y >= wallposition1.Y)
                {
                    speed = 0.5;
                }
                if (position.Y == wallposition2.Y)
                {
                    position.Y += 10;
                }
                else
                {
                    speed = 5;
                }
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
