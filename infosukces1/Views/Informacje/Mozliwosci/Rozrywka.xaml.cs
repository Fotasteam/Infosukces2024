using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using infosukces1.Scripts;

namespace infosukces1.Views.Informacje.Mozliwosci
{
    public sealed partial class Rozrywka : Page
    {
        public Rozrywka()
        {
            this.InitializeComponent();

            List<QuestionQuizTemplateCard> questions = new List<QuestionQuizTemplateCard>()
            {
                new QuestionQuizTemplateCard{ Title = "Czy VR naprawdê uzale¿nia?", Content = "Istniej¹ ju¿ powa¿ne przypadki uzale¿nieñ od wirtualnej rzeczywistoœci. ", Enabled = true, Link = "https://projecteuler.net/" },
                new QuestionQuizTemplateCard{ Title = "Przyklad bez linku", Content = "Opis przykladu bez linku", Enabled = false }
            };

            foreach (var question in questions)
                GridViewQuestions.Items.Add(question);
        }
    }
}
