using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Human_Shapovalova.Classes
{
    public class Russian :Human
    {
        private List<Phrase> Phrases {  get; set; }
        private int stepAudio;
        private int StepAudio
        {
            get { return stepAudio; }
            set
            {
                stepAudio = value;
                if (stepAudio > Phrases.Count - 1) stepAudio = 0;
            }
        }
        public Russian(string Name, string Img):base(Name, Img)
        {
            this.Phrases = AllPhrases();
        }
        public override void Speak(Label Phrase)
        {
            Phrase.Content = Phrases[StepAudio]._Phrase;
            MainWindow.MediaPlayer.Open(new Uri(Phrases[StepAudio].Src));
            MainWindow.MediaPlayer.Play();
            StepAudio++;
        }
        public static List<Phrase> AllPhrases()
        {
            List<Phrase> allPhrases = new List<Phrase>();
            allPhrases.Add(new Phrase("Привет", @"D:\МДК01.01\Voices\Voice1.mp3"));
            allPhrases.Add(new Phrase("Как дела?", @"D:\МДК01.01\Voices\Voice2.mp3"));
            allPhrases.Add(new Phrase("Меня зовут Анна", @"D:\МДК01.01\Voices\Voice3.mp3"));ж
            return allPhrases;
        }
    }
}
