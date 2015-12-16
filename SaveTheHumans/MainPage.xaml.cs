using Save_the_Humans_Test_2.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;


namespace Save_the_Humans_Test_2
{

    public sealed partial class MainPage : Page
    {

        Random random = new Random();
        DispatcherTimer EnemyTimer = new DispatcherTimer();
        DispatcherTimer TargetTimer = new DispatcherTimer();
        bool HumanCaptured = false;


        public MainPage()
        {
            this.InitializeComponent();
            
            EnemyTimer.Tick += EnemyTimer_Tick;
            EnemyTimer.Interval = TimeSpan.FromSeconds(5);

            EnemyTimer.Tick += TargetTimer_Tick;
            EnemyTimer.Interval = TimeSpan.FromSeconds(.2);
        }


        private void TargetTimer_Tick(object sender, object e)
        {
            progressBar.Value += 4;
            if (progressBar.Value >= progressBar.Maximum)
                EndTheGame();
        }

        private void EndTheGame()
        {

            if (!PlayArea.Children.Contains(gameOverText))
            {
                EnemyTimer.Stop();
                TargetTimer.Stop();
                HumanCaptured = false;
                StartButton.Visibility = Visibility.Visible;
                PlayArea.Children.Add(gameOverText);
                
            }
        }
         private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            human.IsHitTestVisible = true;
            HumanCaptured = false;
            progressBar.Value = 0;
            StartButton.Visibility = Visibility.Collapsed;
            PlayArea.Children.Clear();
            PlayArea.Children.Add(target);
            PlayArea.Children.Add(human);
            EnemyTimer.Start();
            TargetTimer.Start();
        }

        void EnemyTimer_Tick(object sender, object e)
        {
            AddAnemy();
        }

        private void AddAnemy()
        {
            ContentControl enemy = new ContentControl();
            enemy.Template = Resources["EnemyTemplate"] as ControlTemplate;
            AnimateEnemy(enemy, 0, PlayArea.ActualWidth - 100, "(Canvas.Left)");
            AnimateEnemy(enemy, random.Next((int)PlayArea.ActualHeight - 100),
            random.Next((int)PlayArea.ActualHeight - 100), "(Canvas.Top)");
            PlayArea.Children.Add(enemy);

            enemy.PointerEntered += enemy_PointerEntered;
        }

        void enemy_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (HumanCaptured)
                EndTheGame();
        }
        
            
            private void AnimateEnemy(ContentControl enemy, double from, double to, string propertyToAnimate)
        {

            Storyboard storyboard = new Storyboard() { AutoReverse = true, RepeatBehavior = RepeatBehavior.Forever};
            DoubleAnimation animation = new DoubleAnimation()
            {

                From = from,
                To = to,
                Duration = new Duration(TimeSpan.FromSeconds(random.Next(8, 10)))
            };

            Storyboard.SetTarget(animation, enemy);
            Storyboard.SetTargetProperty(animation, propertyToAnimate);
            storyboard.Children.Add(animation);
            storyboard.Begin();


        }

            private void human_PointerPressed(object sender, PointerRoutedEventArgs e)
            {
                if (EnemyTimer.IsEnabled) {
                    HumanCaptured = true;
                    human.IsHitTestVisible = false;
                }
            }

            private void target_PointerEntered(object sender, PointerRoutedEventArgs e)
            {
                if (TargetTimer.IsEnabled && HumanCaptured)
                {
                    progressBar.Value = 0;
                    Canvas.SetLeft(target, random.Next(100, (int)PlayArea.ActualWidth - 100));
                    Canvas.SetTop(target, random.Next(100, (int)PlayArea.ActualHeight - 100));
                    Canvas.SetLeft(human, random.Next(100, (int)PlayArea.ActualWidth - 100));
                    Canvas.SetTop(human, random.Next(100, (int)PlayArea.ActualHeight - 100));
                    HumanCaptured = false;
                    human.IsHitTestVisible = true;
                }

            }

            private void PlayArea_PointerMoved(object sender, PointerRoutedEventArgs e)
            {
                if (HumanCaptured)
                {
                    Point pointerPosition = e.GetCurrentPoint(null).Position;
                    Point relativePosition = grid.TransformToVisual(PlayArea).TransformPoint(pointerPosition);
                    if((Math.Abs(relativePosition.X - Canvas.GetLeft(human))>human.ActualWidth*3) 
                        || (Math.Abs(relativePosition.Y - Canvas.GetTop(human))>human.ActualHeight*3))
                    {
                        HumanCaptured = false;
                        human.IsHitTestVisible=true;
                    }

                    else
                    {
                        Canvas.SetLeft(human,relativePosition.X-human.ActualWidth/2);
                        Canvas.SetTop(human,relativePosition.Y-human.ActualHeight/2);
                    }

                }

            }

            private void PlayArea_PointerExited(object sender, PointerRoutedEventArgs e)
            {
                if (HumanCaptured)
                    EndTheGame();
            }

    }
}
