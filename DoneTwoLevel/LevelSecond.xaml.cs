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
using System.Windows.Shapes;

namespace _18_04
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class LevelSecond : Window
    {
        public LevelSecond()
        {
            InitializeComponent();
            clipCake.Stop();
        }

        public int randomAnswer = new Random().Next(1000);
        private int CountErrorsInPlayMusic { get; set; }

        readonly MediaPlayer playMusic = new MediaPlayer();

        private void PlayMusic_Click(object sender, RoutedEventArgs e)
        {
            if (SelectMusic.SelectedItem == null && CountErrorsInPlayMusic < 3)
            {
                MessageBox.Show("Вы не выбрали как будете страдать!");
                CountErrorsInPlayMusic++;
            }
            else if (SelectMusic.SelectedItem == null && CountErrorsInPlayMusic < 6)
            {
                MessageBox.Show("НЕ БЕСИ МЕНЯ!");
                CountErrorsInPlayMusic++;
            }
            else if (SelectMusic.SelectedItem == null && CountErrorsInPlayMusic == 6)
                MessageBox.Show("Ну ладно, ладно, держи ключ: " + randomAnswer.ToString());
            else if (SelectMusic.SelectedIndex == 0)
                CliclOnPlayButton("Music/firstTrack.mp3");
            else if (SelectMusic.SelectedIndex == 1)
                CliclOnPlayButton("Music/secondTrack.mp3");
            else if (SelectMusic.SelectedIndex == 2)
                CliclOnPlayButton("Music/thirdTrack.mp3");
            else if (SelectMusic.SelectedIndex == 3)
                CliclOnPlayButton("Music/fourthTrack.mp3");
        }
        private void CliclOnPlayButton(string url)
        {
            playMusic.Open(new Uri(url, UriKind.RelativeOrAbsolute));
            playMusic.Volume = 50;
            playMusic.Play();
            PlayMusic.Visibility = Visibility.Hidden;
            SelectMusic.Visibility = Visibility.Hidden;
            StopMusic.Visibility = Visibility.Visible;
        }

        private void StopMusic_Click(object sender, RoutedEventArgs e)
        {
            StopMusic.Visibility = Visibility.Hidden;
            text1.Visibility = Visibility.Visible;
            KeyOnBoard.Visibility = Visibility.Visible;
        }

        private void ClickKeyOnBoard(object sender, RoutedEventArgs e)
        {
            KeyOnBoard.Visibility = Visibility.Hidden;
            text1.Visibility = Visibility.Hidden;
            text2.Visibility = Visibility.Visible;
            Coffe.Visibility = Visibility.Visible;
        }

        private void Coffe_Click(object sender, RoutedEventArgs e)
        {
            text2.Visibility = Visibility.Hidden;
            Coffe.Visibility = Visibility.Hidden;
            text3.Visibility = Visibility.Visible;
            me.Visibility = Visibility.Visible;
            ButtonMe.Visibility = Visibility.Visible;

        }

        private void ButtonMe_Click(object sender, RoutedEventArgs e)
        {
            ButtonMe.Visibility = Visibility.Hidden;
            var label = new Label();
            label.Content = randomAnswer.ToString();
            label.Foreground = Brushes.White;
            label.FontSize = 18;
            text3.Visibility = Visibility.Hidden;
            label.FontWeight = FontWeights.UltraBold;
            Answer.Children.Add(label);
            Relax.Visibility = Visibility.Visible;
            me.Visibility = Visibility.Hidden;
            playMusic.Stop();
        }

        private void ForFun(object sender, RoutedEventArgs e)
        {
            clipCake.Visibility = Visibility.Visible;
            clipCake.Play();
            Dance.Play();
            Relax.Visibility = Visibility.Hidden;

        }

        private void GoNextLevel_Click(object sender, RoutedEventArgs e)
        {
            var levelThird = new LevelThird();
            if (password.Text == randomAnswer.ToString())
            {
                this.Close();
                playMusic.Close();
                levelThird.Show();
            }
            else
                MessageBox.Show("Неверный ключ");
        }

        private void Dance_MediaEnded(object sender, RoutedEventArgs e)
        {
            Dance.Position = TimeSpan.FromMilliseconds(1);
            Dance.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var adminPanel = new AdminPanel();
            this.Close();
            adminPanel.Show();
        }
    }
}
