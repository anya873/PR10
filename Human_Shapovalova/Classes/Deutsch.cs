using System.Collections.Generic;
using System.Windows.Controls;

namespace Human_Shapovalova.Classes
{
    public class Deutsch : Human
    {
        private List<Phrase> Phrases { get; set; }
        private int stepAudio;

        private int StepAudio
        {
            get { return stepAudio; }
            set
            {
                if (Phrases == null || Phrases.Count == 0) { stepAudio = 0; return; }
                stepAudio = value;
                if (stepAudio > Phrases.Count - 1) stepAudio = 0;
            }
        }

        public Deutsch(string Name, string Img) : base(Name, Img)
        {
            this.Phrases = AllPhrases();
        }

        public override void Speak(Label Phrase)
        {
            Phrase.Content = Phrases[StepAudio]._Phrase;
            MainWindow.MediaPlayer.Open(new System.Uri(Phrases[StepAudio].Src));
            MainWindow.MediaPlayer.Play();
            StepAudio++;
        }

        public static List<Phrase> AllPhrases()
        {
            List<Phrase> allPhrases = new List<Phrase>();
            allPhrases.Add(new Phrase("Hallo", @"D:\МДК01.01\Voices\voice_n1.mp3"));
            allPhrases.Add(new Phrase("Wie geht's?", @"D:\МДК01.01\Voices\voice_n2.mp3"));
            allPhrases.Add(new Phrase("Ich heiße Hans", @"D:\МДК01.01\Voices\voice_n3.mp3"));ж
            return allPhrases;
        }
    }
}