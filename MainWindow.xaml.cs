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
        
        double speed = 5;
        Point position = new Point();
        Point wallposition3 = new Point();
        Point wallposition4 = new Point();
        Point wallposition1 = new Point();
        Point wallposition2 = new Point();
        Rectangle car = new Rectangle();
        Polygon Wall = new Polygon();
        System.Windows.Point WallPoint1 = new System.Windows.Point(0, 200);
            System.Windows.Point WallPoint2 = new System.Windows.Point(0, 250);
            System.Windows.Point WallPoint3 = new System.Windows.Point(300, 200);
            System.Windows.Point WallPoint4 = new System.Windows.Point(350, 250);
            System.Windows.Point WallPoint5 = new System.Windows.Point(350, 0);
            System.Windows.Point WallPoint6 = new System.Windows.Point(300, 0);
            PointCollection WallPoints = new PointCollection();

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
            Wall.Stroke = System.Windows.Media.Brushes.Black;
            Wall.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            Wall.StrokeThickness = 2;
            Wall.HorizontalAlignment = HorizontalAlignment.Left;
            Wall.VerticalAlignment = VerticalAlignment.Center;
            
            WallPoints.Add(WallPoint1);
            WallPoints.Add(WallPoint2);
            WallPoints.Add(WallPoint4);
            WallPoints.Add(WallPoint5);
            WallPoints.Add(WallPoint6);
            WallPoints.Add(WallPoint3);
            Wall.Points = WallPoints;
            Track.Children.Add(Wall);
            
            Track.Children.Add(car);
            position.X = 100;
            position.Y = 100;
            Canvas.SetLeft(car, position.X);
            Canvas.SetTop(car, position.Y);
            
            car.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            wallposition1 = WallPoint1;
            wallposition2 = WallPoint2;
            wallposition3 = WallPoint4;
            wallposition4 = WallPoint6;
            
            if (Keyboard.IsKeyDown(Key.Down))
            {

                position.Y += speed;
                Canvas.SetTop(car, position.Y);
                if (position.Y + 50 >= wallposition1.Y && position.Y + 50 <= wallposition2.Y)
                {
                    speed = 0.5;


                    if (position.Y + 50 == WallPoint2.Y)
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
                position.Y -= speed;
                Canvas.SetTop(car, position.Y);
                if (position.Y == wallposition2.Y && position.Y >= wallposition1.Y)
                {
                    speed = 0.5;

                    if (position.Y == wallposition2.Y)
                    {
                        position.Y += 10;
                    }
                }
                else
                {
                    speed = 5;
                }
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                position.X += speed;
                Canvas.SetLeft(car, position.X);
                if (position.X + 50 <= wallposition3.X && position.X + 50 >= wallposition4.X)
                {
                    speed = 0.5;

                    if (position.X + 50 == WallPoint4.X)
                    {
                        
                        position.X -= 10;
                        Canvas.SetLeft(car, position.X);
                    }
                }
                else
                {
                    speed = 5;
                }
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                position.X -= 10;
                Canvas.SetLeft(car, position.X);
                if (position.X + 50 >= wallposition3.X && position.X + 50 <= WallPoint6.X)
                {
                    speed = 0.5;

                    if (position.X + 50 == wallposition3.X)
                    {
                        position.X -= 20;
                    }
                }
                else
                {
                    speed = 5;
                }
            }


        }
            
    }
        
}
