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
    public sealed partial class TapTap_4 : Page
    {
        List<AllButtonsClass> buttons;
        DispatcherTimer ReadyTimer;
        private bool _isInitialized = false;
        private bool _isItemShown = false;
        Button selected;
        private int _score = 0;
        AllButtonsClass chosen;
        int _time;
        int Timer = 59;
        DispatcherTimer _dispatchTimer;

        public TapTap_4()
        {
            this.InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            buttons = new List<AllButtonsClass>();
            ReadyTimer = new DispatcherTimer();
            _dispatchTimer = new DispatcherTimer();
            PopulateButtons();
            ButtonEnaDisBle(false);
            RegisterTimers();
            ReadyTimer.Start();
            UpdateScore();
            _time = 800;
            TimingTextBlock.Text = Timer.ToString();
            _dispatchTimer.Start();
        }

        private void ButtonEnaDisBle(bool value)
        {
            foreach (var button in buttons)
            {
                button._button.IsEnabled = value;
            }
        }

        private void UpdateScore()
        {
            CountTextBlock.Text = _score.ToString();
        }

        private void RegisterTimers()
        {
            if (_isInitialized)
            {
                ReadyTimer.Tick += ReadyTimer_Tick;
                ReadyTimer.Interval = new TimeSpan(0, 0, 2);
                _dispatchTimer.Tick += _dispatchTimer_Tick;
                _dispatchTimer.Interval = new TimeSpan(0, 0, 1);
            }
        }

        private void _dispatchTimer_Tick(object sender, object e)
        {
            if (Timer == 0)
            {
                EndGame();
                return;
            }
            Timer -= 1;
            TimingTextBlock.Text = Timer.ToString();
            if (Timer < 10)
            {
                try
                {
                    Uri path = new Uri("ms-appx:///Assets/HeartBeat.wav");
                    MyMediaElement.Source = path;
                    MyMediaElement.Play();
                }
                catch (Exception)
                {

                    Debug.WriteLine("Error reading file");
                }
                SolidColorBrush brush = new SolidColorBrush(Colors.Red);
                TimingTextBlock.Foreground = brush;
            }
        }

        private void EndGame()
        {
            MyMediaElement.Stop();
            CommentTextBlock.Text = "Game Over";
            UpdateScore();
            ButtonEnaDisBle(false);
            ReadyTimer.Stop();
            ReadyTimer.Tick -= ReadyTimer_Tick;
            ReadyTimer = null;
            _dispatchTimer.Stop();
            _dispatchTimer.Tick -= _dispatchTimer_Tick;
            _dispatchTimer = null;
            MyMediaElement.Source = null;
            MyMediaElement = null;
        }

        private int TimePicker()
        {
            if (_time > 600)
            {
                return _time - 20;
            }
            return _time;


        }
        private void ReadyTimer_Tick(object sender, object e)
        {
            if (!_isItemShown)
            {
                selected = PickARandomGrid();
                UpdateUI(selected);
                _isItemShown = true;
                ButtonEnaDisBle(true);
                _time = TimePicker();
                ReadyTimer.Interval = new TimeSpan(0, 0, 0, 0, _time);
            }
            else if (_isItemShown)
            {
                ClearUI(selected);
                _isItemShown = false;
                ButtonEnaDisBle(false);
            }
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
            _isInitialized = true;
        }

        private Button PickARandomGrid()
        {
            int Count = buttons.Count();
            Random random = new Random();
            int randNumber = random.Next(Count);
            chosen = buttons[randNumber];
            Button selected = (Button)buttons[randNumber]._button;
            buttons[randNumber]._isChosen = true;
            return selected;
        }

        private void UpdateUI(Button butt)
        {
            char picked = PickARandomCharacter();
            butt.Content = picked;
        }

        private void ClearUI(Button butt)
        {
            butt.Content = "";

        }

        private char PickARandomCharacter()
        {
            Random rand = new Random();
            int numb = rand.Next(26);
            char letter = (char)('a' + numb);
            return letter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReadyTimer.Stop();
            ButtonEnaDisBle(false);
            Button button = (Button)sender;

            if (selected != null && chosen != null)
            {
                if (button == chosen._button)
                {
                    _score++;
                    CommentTextBlock.Text = "got it";
                    UpdateScore();
                }
                else
                {

                    CommentTextBlock.Text = "Missed";
                }
            }
            ClearUI(selected);
            _isItemShown = false;
            ReadyTimer.Start();
        }

        private void ContLevel2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game4x4));
        }
    }
}
