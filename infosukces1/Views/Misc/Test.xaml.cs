using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using infosukces1.Scripts;
using Windows.Storage;

namespace infosukces1.Views.Misc
{
    public sealed partial class Test : Page
    {
        private int currentQuestion = 0;

        List<QuestionTemplate> questions = new List<QuestionTemplate>()
        {
            new QuestionTemplate{ QuestionDescription="Gogle AR powsta�e w 2016 roku w laboratorium Microsoft - projekt, kt�ry wyprzedzi� sw�j czas to:", QuestionAnswer=2, QuestionAnswerAContent="A. Apple Vision Pro", QuestionAnswerBContent="B. IVAS", QuestionAnswerCContent="C. Hololens", QuestionAnswerDContent="D. Valve Index" },
            new QuestionTemplate{ QuestionDescription="Urz�dzenie Nintendo wypuszczone w latach 90' ubieg�ego wieku, pierwsza konsola do gier VR nosi nazw�:", QuestionAnswer=0, QuestionAnswerAContent="A. Virtual Boy", QuestionAnswerBContent="B. Nintendo Switch", QuestionAnswerCContent="C. Nintendo 64", QuestionAnswerDContent="D. Super Nintendo Entertainment System" },
            new QuestionTemplate{ QuestionDescription="Kt�re z wymienionych poni�ej jest skutkiem uzale�nienia od VR?", QuestionAnswer=1, QuestionAnswerAContent="A. Problemy Socjalne", QuestionAnswerBContent="B. Wp�yw na zdrowie", QuestionAnswerCContent="C. Stymulacja sensoryczna", QuestionAnswerDContent="D. Efekt psychologiczny" },
            new QuestionTemplate{ QuestionDescription="Kt�re z poni�szych urz�dze� jest systemem AR?", QuestionAnswer=3, QuestionAnswerAContent="A. HTC Vive", QuestionAnswerBContent="B. Meta Quest", QuestionAnswerCContent="C. Valve Index", QuestionAnswerDContent="D. Apple Vision Pro" },
            new QuestionTemplate{ QuestionDescription="W kt�rej z poni�szych dziedzin wykorzystuje si� g��wnie VR?", QuestionAnswer=1, QuestionAnswerAContent="A. Ogl�danie film�w", QuestionAnswerBContent="B. Gry komputerowe", QuestionAnswerCContent="C. Biznes", QuestionAnswerDContent="D. Handel" },
            new QuestionTemplate{ QuestionDescription="Czym jest IVAS?", QuestionAnswer=0, QuestionAnswerAContent="A. Nieudanym projektem wojska ameryka�skiego", QuestionAnswerBContent="B. Nowoczesnymi goglami Microsoft", QuestionAnswerCContent="C. Firm� tworz�c� gogle VR", QuestionAnswerDContent="D. Wielozmys�owym symulatorem stworzonym w latach 60'" },
            new QuestionTemplate{ QuestionDescription="Jak nazywa�o si� urz�dzenie Morton'a Heilig'a", QuestionAnswer=2, QuestionAnswerAContent="A. Hololens", QuestionAnswerBContent="B. The Sword of Damacoles", QuestionAnswerCContent="C. Sensorama", QuestionAnswerDContent="D. Amiga 600" },
            new QuestionTemplate{ QuestionDescription="Urz�dzenie Mortona Heilinga o nazwie Sensorama, uznawane za pocz�tek ery VR, powsta�o w roku:", QuestionAnswer=1, QuestionAnswerAContent="A. 1954", QuestionAnswerBContent="B. 1962", QuestionAnswerCContent="C. 1991", QuestionAnswerDContent="D. 1998" },
            new QuestionTemplate{ QuestionDescription="Kim by� Palmer Luckey?", QuestionAnswer=2, QuestionAnswerAContent="A. By� to pionier technologi VR w latach 90'", QuestionAnswerBContent="B. By� to prezes Nintendo", QuestionAnswerCContent="C. By� to tw�rca Oculusa", QuestionAnswerDContent="D. By� to pionier technologi AR" },
            new QuestionTemplate{ QuestionDescription="Co umo�liwia zastosowanie VR w medycynie?", QuestionAnswer=1, QuestionAnswerAContent="A. Konsultacje medyczne online", QuestionAnswerBContent="B. Realistyczne treningi", QuestionAnswerCContent="C. Obs�uga rejestracji pacjent�w", QuestionAnswerDContent="D. Wizyty w klinice online" },
            new QuestionTemplate{ QuestionDescription="Czego nie zawieraj� gogle VR?", QuestionAnswer=3, QuestionAnswerAContent="A. G�o�nik�w lub s�uchawek", QuestionAnswerBContent="B. Czujnik�w ruchu", QuestionAnswerCContent="C. Ekranu", QuestionAnswerDContent="D. Emulator�w zapach�w" },
            new QuestionTemplate{ QuestionDescription="Do czego mo�e prowadzi� nadmierne przebywanie w przestrzeni wirtualnej?", QuestionAnswer=0, QuestionAnswerAContent="A. Do izolacji spo�ecznej", QuestionAnswerBContent="B. Do poprawy relacji rodzinnych", QuestionAnswerCContent="C. Do wyleczenia skoliozy", QuestionAnswerDContent="D. Do poprawy wzroku" }
        };
        
        public Test()
        {
            this.InitializeComponent();

            NextRound();
        }

        private void NextRound()
        {
            TextBlockQuestionName.Text = "Pytanie " + (currentQuestion + 1).ToString() + "/" + questions.Count.ToString();
            TextBlockQuestionDescription.Text = questions[currentQuestion].QuestionDescription;
            CheckBoxA.Content = questions[currentQuestion].QuestionAnswerAContent;
            CheckBoxB.Content = questions[currentQuestion].QuestionAnswerBContent;
            CheckBoxC.Content = questions[currentQuestion].QuestionAnswerCContent;
            CheckBoxD.Content = questions[currentQuestion].QuestionAnswerDContent;

            CheckBoxA.IsEnabled = true;
            CheckBoxB.IsEnabled = true;
            CheckBoxC.IsEnabled = true;
            CheckBoxD.IsEnabled = true;
            ButtonCheck.IsEnabled = true;
            ButtonSend.IsEnabled = false;
        }

        private void checkAnswer(int initiator)
        {
            if (initiator == questions[currentQuestion].QuestionAnswer) //dobra odpowiedz
            {
                InfoBarBottom.Severity = InfoBarSeverity.Success;
                InfoBarBottom.Title = "Dobra odpowied�!";
                InfoBarBottom.Message = "Gratulacje :)";
                InfoBarBottom.IsOpen = true;
            }
            else //zla odpowiedz
            {
                InfoBarBottom.Severity = InfoBarSeverity.Error;
                InfoBarBottom.Title = "Z�a odpowied�!";
                InfoBarBottom.Message = "Poprawna odpowied� to: " + (questions[currentQuestion].QuestionAnswer == 0 ? "A" : (questions[currentQuestion].QuestionAnswer == 1 ? "B" : (questions[currentQuestion].QuestionAnswer == 2 ? "C" : "D")));
                InfoBarBottom.IsOpen = true;
            }

            CheckBoxA.IsEnabled = false;
            CheckBoxB.IsEnabled = false;
            CheckBoxC.IsEnabled = false;
            CheckBoxD.IsEnabled = false;
            ButtonCheck.IsEnabled = false;
            ButtonSend.IsEnabled = currentQuestion + 1 == questions.Count ? false : true;
        }

        private void CheckBoxA_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxB.IsChecked = false;
            CheckBoxC.IsChecked = false;
            CheckBoxD.IsChecked = false;
        }

        private void CheckBoxB_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxA.IsChecked = false;
            CheckBoxC.IsChecked = false;
            CheckBoxD.IsChecked = false;
        }

        private void CheckBoxC_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxB.IsChecked = false;
            CheckBoxA.IsChecked = false;
            CheckBoxD.IsChecked = false;
        }

        private void CheckBoxD_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxB.IsChecked = false;
            CheckBoxC.IsChecked = false;
            CheckBoxA.IsChecked = false;
        }

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            int initiator = -1;
            if (CheckBoxA.IsChecked == true) initiator = 0;
            else if (CheckBoxB.IsChecked == true) initiator = 1;
            else if (CheckBoxC.IsChecked == true) initiator = 2;
            else if (CheckBoxD.IsChecked == true) initiator = 3;

            if (initiator == -1)
            {
                InfoBarBottom.Title = "Uwaga!";
                InfoBarBottom.Message = "Zaznacz przynajmniej jedn� odpowied�, aby sprawdzi� czy jest poprawna.";
                InfoBarBottom.IsOpen = true;
            }
            else checkAnswer(initiator);
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            currentQuestion++;
            NextRound();
        }
    }
}