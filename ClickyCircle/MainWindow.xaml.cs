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
using System.Windows.Threading;

namespace ClickyCircle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {     
            DispatcherTimer gameTimer = new DispatcherTimer(); // create a new instance of the dispatcher time called gameTimer

            List<Ellipse> removeThis = new List<Ellipse>(); // make a list of ellipse called remove this it will be used to remove the circles we click on from the game

            // below are all the necessary integers declared for this game
            int spawnRate = 60; // this is the default spawn rate of the circles
            int currentRate; // current rate will help add an interval between spawning of the circles
            int lastScore = 0; // this will hold the last played score for this game
            int health = 350; // total health of the player in the begining of the game
            int posX; // x position of the circles
            int posY; // y position of the circles
            int score = 0; // current score for the game

            double growthRate = 0.6; // the default growth rate for each circle in the game

            Random rand = new Random(); // a random number generator

            // below are the two media player classes one for the clicked sound and one for the pop sound

            MediaPlayer playClickSound = new MediaPlayer();
            MediaPlayer playerPopSound = new MediaPlayer();

            // below are the two URI location finder for both mp3 files we imported for this game

            Uri ClickedSound;
            Uri PoppedSound;

            // colour for the circles
            Brush brush;
        
        public MainWindow()
        {
            InitializeComponent();

            // inside the main constructor we will write the instructors for the begining of the game

            gameTimer.Tick += GameLoop; // set the game timer event called game loop
            gameTimer.Interval = TimeSpan.FromMilliseconds(20); // this time will tick every 20 milliseconds
            gameTimer.Start(); // start the timer 

            currentRate = spawnRate; // set the current rate to the spawn rate number

            // locate both of the mp3 files inside sound folder and add them to the correct URI below

            ClickedSound = new Uri("pack://siteoforigin:,,,/sound/clickedpop.mp3");
            PoppedSound = new Uri("pack://siteoforigin:,,,/sound/pop.mp3");

        }

        private void GameLoop(object sender, EventArgs e)
        {

            // this is the game loop event, all of the instructions inside of this event will run each time the timer ticks

            // first we update the score and show the last score on the labels
            txtScore.Content = "Score: " + score;
            txtLastScore.Content = "Last Score: " + lastScore;

            // reduce 2 from the current rate as the time runs
            currentRate -= 2;

            // if the current rate is below 1 
            if (currentRate < 1)
            {
                // reset current rate back to spawn rate
                currentRate = spawnRate;

                // generate a random number for the X and Y value for the circles
                posX = rand.Next(15, 700);
                posY = rand.Next(50, 350);

                // generate a random colour for the circles and save it inside the brush
                brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255)));

                // create a new ellipse called circle
                // this circle will have a tag, default height and width, border colour and fill
                Ellipse circle = new Ellipse
                {

                    Tag = "circle",
                    Height = 10,
                    Width = 10,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Fill = brush

                };

                // place the newly created circle to the canvas with the X and Y position generated earlier
                Canvas.SetLeft(circle, posX);
                Canvas.SetTop(circle, posY);
                // finally add the circle to the canvas
                MyCanvas.Children.Add(circle);
            }

            // the for each loop below will find each ellipse inside of the canvas and grow it  

            foreach (var x in MyCanvas.Children.OfType<Ellipse>())
            {
                // we search the canvas and find the ellipse that exists inside of it

                x.Height += growthRate; // grow the height of the circle
                x.Width += growthRate; // grow the width of the circle
                x.RenderTransformOrigin = new Point(0.5, 0.5); // grow from the centre of the circle by resetting the transform origin

                // if the width of the circle goes above 70 we want to pop the circle

                if (x.Width > 70)
                {
                    // if the width if above 70 then add this circle to the remove this list
                    removeThis.Add(x);
                    health -= 15; // reduce health by 15 
                    playerPopSound.Open(PoppedSound); // load the popped sound uri inside of the player pop sound media player
                    playerPopSound.Play(); // now play the pop sound

                }

            } // end of for each loop

            // if health is above 1 
            if (health > 1)
            {
                // link the health bar rectangle to the health integer
                healthBar.Width = health;
            }
            else
            {
                // if health is below 1 then run the game over function
                GameOverFunction();
            }

            // to remove ethe ellipse from the game we need another for each loop
            foreach (Ellipse i in removeThis)
            {
                // this for each loop will search for each ellipse that exist inside of the remove this list
                MyCanvas.Children.Remove(i); // when it finds one it will remove it from the canvas
            }

            // if the score if above 5 
            if (score > 5)
            {
                // speed up the spawn rate
                spawnRate = 25;
            }

            // if the score is above 20 
            if (score > 20)
            {
                // speed up the growth and and spawn rate
                spawnRate = 15;
                growthRate = 1.5;
            }


        }

        private void CanvasClicking(object sender, MouseButtonEventArgs e)
        {
            // this click event is linked inside of the canvas, we need to check if we have clicked on the ellipse

            // if the original source clicked is a ellipse
            if (e.OriginalSource is Ellipse)
            {
                // create a local ellipse and link it to the original source
                Ellipse circle = (Ellipse)e.OriginalSource;

                // now remove that ellipse we clicked on from the canvas
                MyCanvas.Children.Remove(circle);

                // add 1 to the score
                score++;

                // load the clicked sound uri to the play click sound media player and play the sound file
                playClickSound.Open(ClickedSound);
                playClickSound.Play();

            }
        }
        private void GameOverFunction()
        {
            // this is the game over function 

            gameTimer.Stop(); // first stop the game timer

            // show a message box to the end screen and wait for the player to click ok
            MessageBox.Show("Game Over" + Environment.NewLine + "You Scored: " + score + Environment.NewLine + "Click Ok to play again!");

            // after the player clicked ok now we need to do a for each loop
            foreach (var y in MyCanvas.Children.OfType<Ellipse>())
            {
                // find all of the existing ellipse that are on the screen and add them to the remove this list
                removeThis.Add(y);
            }
            // here we need another for each loop to remove everything from inside of the remove this list
            foreach (Ellipse i in removeThis)
            {
                MyCanvas.Children.Remove(i);
            }

            // reset all of the game values to default including clearling all of the ellipses from the remove this list
            growthRate = .6;
            spawnRate = 60;
            lastScore = score;
            score = 0;
            currentRate = 5;
            health = 350;
            removeThis.Clear();
            gameTimer.Start();


        }
    }
}
