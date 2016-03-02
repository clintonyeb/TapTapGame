using MatchingGame.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MatchingGame.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game4x4 : Page
    {
        List<AllButtonsClass> buttons;
        DispatcherTimer _dispatchTimer;
        private double _score = 0;
        List<char> icons;
        SolidColorBrush brush = new SolidColorBrush(Colors.White);
        AllButtonsClass firstButton = null;
        AllButtonsClass secondButton = null;
        const int perfect = 16;
        private int _moves;

        public Game4x4()
        {
            this.InitializeComponent();
            buttons = new List<AllButtonsClass>();
            icons = new List<char>();
            _dispatchTimer = new DispatcherTimer();
            _dispatchTimer.Tick += _dispatchTimer_Tick;
            _dispatchTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            PopulateButtons();
            GetIcons();
            PopulateCells();
            UpdateScore();
        }

        private void UpdateScore()
        {
            MovesTextBlock.Text = _moves.ToString();
        }

        private void _dispatchTimer_Tick(object sender, object e)
        {
            Reveal(firstButton, false);
            Reveal(secondButton, false);
            firstButton = null;
            secondButton = null;
            DisableButtons(false);
            _dispatchTimer.Stop();
            CommentTextBlock.Text = "Don't forget your mistakes!";
            UpdateScore();
        }

        private void ButtonClick(Button button)
        {
            DisableButtons(true);
            if (firstButton == null)
            {
                firstButton = new AllButtonsClass();
                firstButton._button = button;
                Reveal(firstButton, true);
                firstButton._isChosen = true;
                DisableButtons(false);
                return;
            }
            else if (firstButton != null && secondButton == null)
            {
                secondButton = new AllButtonsClass();
                secondButton._button = button;
                Reveal(secondButton, true);
                _moves++;
                bool answer = CheckSelected(firstButton, secondButton);

                if (answer)
                {
                    _score++;
                    UpdateScore();
                    CommentTextBlock.Text = "Great!";
                    firstButton = null;
                    secondButton = null;
                    DisableButtons(false);
                    bool complete = CheckGameComplete();
                    if (complete)
                    {
                        CommentTextBlock.Text = "Game Completed";
                    }
                }
                else
                {
                    CommentTextBlock.Text = "Missed!";
                    try
                    {
                        Uri path = new Uri("ms-appx:///Assets/Disappearing.wav");
                        MyMediaElement.Source = path;
                        MediaPlayerStoryboard.Begin();
                    }
                    catch (Exception)
                    {

                        Debug.WriteLine("Error reading file");
                    }
                    _dispatchTimer.Start();
                }
            }
        }

        private bool CheckGameComplete()
        {
            foreach (var button in buttons)
            {
                if (button._button.Opacity != 1)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckSelected(AllButtonsClass first, AllButtonsClass second)
        {
            if (first._button.Content.ToString() == second._button.Content.ToString())
            {
                return true;
            }
            return false;
        }

        private void DisableButtons(bool state)
        {
            if (state)
            {
                foreach (var item in buttons)
                {
                    if (item._alreadySelected == false)
                    {
                        item._button.IsEnabled = false;
                    }

                }
            }
            else
            {
                foreach (var item in buttons)
                {
                    if (item._alreadySelected == false)
                    {
                        item._button.IsEnabled = true;
                    }

                }
            }

        }

        private void Reveal(AllButtonsClass butt, bool reason)
        {
            if (reason)
            {
                butt._button.Opacity = 1;
            }
            else
                butt._button.Opacity = 0;
        }

        private void GetIcons()
        {
            while (icons.Count < buttons.Count)
            {
                char charSelected = PickARandomCharacter();
                icons.Add(charSelected);

            }

        }

        private void PopulateCells()
        {
            Random rand = new Random();
            foreach (var button in buttons)
            {
                int num = rand.Next(icons.Count);

                button._button.Content = icons[num];
                icons.RemoveAt(num);
            }


        }

        private char PickARandomCharacter()
        {
            Random rand = new Random();
            int numb = rand.Next(26);
            char letter = (char)('a' + numb);
            foreach (var item in icons)
            {
                if (letter == item)
                {
                    PickARandomCharacter();
                }
            }
            return letter;
        }

        private void PopulateButtons()
        {
            buttons.Add(new AllButtonsClass { _button = Button1 });
            buttons.Add(new AllButtonsClass { _button = Button2 });
            buttons.Add(new AllButtonsClass { _button = Button3 });
            buttons.Add(new AllButtonsClass { _button = Button4 });
            buttons.Add(new AllButtonsClass { _button = Button5 });
            buttons.Add(new AllButtonsClass { _button = Button6 });
            buttons.Add(new AllButtonsClass { _button = Button7 });
            buttons.Add(new AllButtonsClass { _button = Button8 });
            buttons.Add(new AllButtonsClass { _button = Button9 });
            buttons.Add(new AllButtonsClass { _button = Button10 });
            buttons.Add(new AllButtonsClass { _button = Button11 });
            buttons.Add(new AllButtonsClass { _button = Button12 });
            buttons.Add(new AllButtonsClass { _button = Button13 });
            buttons.Add(new AllButtonsClass { _button = Button14 });
            buttons.Add(new AllButtonsClass { _button = Button15 });
            buttons.Add(new AllButtonsClass { _button = Button16 });
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button sen = (Button)sender;
            if (sen.Opacity == 1)
            {
                return;
            }
            ButtonClick(sen);
        }
        private void ContLevel2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game4x4_2));
        }
    }
}
