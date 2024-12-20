using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using infosukces1.Scripts;
using Windows.UI;

namespace infosukces1.Views.Misc
{
    public sealed partial class Test : Page
    {
        private int currentQuestion = 0;

        List<QuestionTemplate> questions = new List<QuestionTemplate>()
        {
            new QuestionTemplate{ QuestionDescription="Opis Pytania", QuestionAnswer=0, QuestionAnswerAContent="A", QuestionAnswerBContent="B", QuestionAnswerCContent="C", QuestionAnswerDContent="D" },
            new QuestionTemplate{ QuestionDescription="Opis Pytania 2", QuestionAnswer=3, QuestionAnswerAContent="A", QuestionAnswerBContent="B", QuestionAnswerCContent="C", QuestionAnswerDContent="D" }
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
            currentQuestion++;

            CheckBoxA.IsEnabled = true;
            CheckBoxB.IsEnabled = true;
            CheckBoxC.IsEnabled = true;
            CheckBoxD.IsEnabled = true;
            ButtonCheck.IsEnabled = true;
            ButtonSend.IsEnabled = false;
        }

        private void checkAnswer(int initiator)
        {
            switch (initiator)
            {
                case 0:
                    if (initiator == questions[currentQuestion - 1].QuestionAnswer) //dobra odpowiedz
                    {
                        InfoBarBottom.Severity = InfoBarSeverity.Success;
                        InfoBarBottom.Title = "Dobra odpowiedü!";
                        InfoBarBottom.Message = "Gratulacje :)";
                        InfoBarBottom.IsOpen = true;
                    }
                    else //zla odpowiedz
                    {
                        InfoBarBottom.Severity = InfoBarSeverity.Error;
                        InfoBarBottom.Title = "Z≥a odpowiedü!";
                        InfoBarBottom.Message = "Poprawna odpowiedü to: " + (questions[currentQuestion - 1].QuestionAnswer == 0 ? "A" : (questions[currentQuestion - 1].QuestionAnswer == 1 ? "B" : (questions[currentQuestion - 1].QuestionAnswer == 2 ? "C" : "D")));
                        InfoBarBottom.IsOpen = true;
                    }

                    CheckBoxA.IsEnabled = false;
                    CheckBoxB.IsEnabled = false;
                    CheckBoxC.IsEnabled = false;
                    CheckBoxD.IsEnabled = false;
                    ButtonCheck.IsEnabled = false;
                    ButtonSend.IsEnabled = true;
                    break;
            }        
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
                InfoBarBottom.Message = "Zaznacz przynajmniej jednπ odpowiedü, aby sprawdziÊ czy jest poprawna.";
                InfoBarBottom.IsOpen = true;
            }
            else checkAnswer(initiator);
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            NextRound();
        }
    }
}