using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Human_Shapovalova.Elements
{
    public partial class Item : UserControl
    {
        Classes.Human Human;

        public Item(object Data)
        {
            InitializeComponent();
            this.Human = Data as Classes.Human;
            if (this.Human == null) return;

            img.Source = new BitmapImage(new Uri(this.Human.Img));
            name.Content = this.Human.Name;
            lrace.Content = Data.GetType().Name;
        }

        private void Speak(object sender, MouseButtonEventArgs e)
        {
            Human?.Speak(text);
        }

        public void SpeakPublic()
        {
            Human?.Speak(text);
        }
    }
}