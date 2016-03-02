using MatchingGame.Views;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MatchingGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Level1Button_Click(object sender, RoutedEventArgs e)
        {
            //BackButton.Visibility = Visibility.Visible;
            MyFrame.Navigate(typeof(Game1x1));
        }

        private void Level2Button_Click(object sender, RoutedEventArgs e)
        {
            //BackButton.Visibility = Visibility.Visible;
            MyFrame.Navigate(typeof(Game2x2));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(MainPage));
        }

        private void Level3Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Game2x2_2));
        }

        private void Level4Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Game2x2_3));
        }

        private void Level5Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TapTap));
        }

        private void Level6Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game2x2_4));
        }

        private void Level7Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TapTap_2));
        }

        private void Level8Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Game4x4));
        }

        private void Level9Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Game4x4_2));
        }

        private void Level10Button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(TapTap_4));
        }
    }
}
