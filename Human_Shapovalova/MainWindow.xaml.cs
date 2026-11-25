using Human_Shapovalova.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Human_Shapovalova
{
    public partial class MainWindow : Window
    {
        public static MediaPlayer MediaPlayer = new MediaPlayer();

        private Classes.Russian Russian = new Classes.Russian("Анна", @"pack://application:,,,/Images/ic_russian.png");
        private Classes.English English = new Classes.English("Боб", @"pack://application:,,,/Images/ic_english.png");
        private Classes.Deutsch Deutsch = new Classes.Deutsch("Ганс", @"pack://application:,,,/Images/ic_english.png");

        private List<Elements.Item> items = new List<Elements.Item>();
        private DispatcherTimer dialogTimer;
        private int dialogIndex = 0;

        public MainWindow()
        {
            InitializeComponent();

            Elements.Item itemRussian = new Elements.Item(Russian);
            Elements.Item itemEnglish = new Elements.Item(English);
            Elements.Item itemDeutsch = new Elements.Item(Deutsch);

            items.Add(itemRussian);
            items.Add(itemEnglish);
            items.Add(itemDeutsch);

            parent.Children.Add(itemRussian);
            parent.Children.Add(itemEnglish);
            parent.Children.Add(itemDeutsch);

            dialogTimer = new DispatcherTimer();
            dialogTimer.Interval = TimeSpan.FromSeconds(3);
            dialogTimer.Tick += DialogTimer_Tick;
        }

        private void DialogBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dialogTimer.IsEnabled)
            {
                dialogTimer.Stop();
                return;
            }

            dialogIndex = 0;
            DialogTimer_Tick(null, null);
            dialogTimer.Start();
        }

        private void DialogTimer_Tick(object sender, EventArgs e)
        {
            if (items.Count == 0) return;

            items[dialogIndex % items.Count].SpeakPublic();
            dialogIndex++;
        }
    }
}