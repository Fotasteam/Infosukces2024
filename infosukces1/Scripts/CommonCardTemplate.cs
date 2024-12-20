using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace infosukces1.Scripts
{
    public class QuestionQuizTemplateCard
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public bool Enabled { get; set; }

        public ICommand WebsiteOpeningCommand
        {
            get
            {
                return new CommadEventHandler<object>((obj) => this.OpenWebsite(obj));
            }
        }

        private void OpenWebsite(object obj)
        {
            //Debug.WriteLine("Website opened");
        }

        public class CommadEventHandler<T> : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public Action<T> action;

            public bool CanExecute(object parameter)
            {
                if (parameter == null || string.IsNullOrEmpty(parameter.ToString()))
                    return false;
                return true;
            }

            public void Execute(object parameter)
            {
                this.action((T)parameter);
                Process.Start(new ProcessStartInfo { FileName = parameter.ToString(), UseShellExecute = true });
            }

            public CommadEventHandler(Action<T> action)
            {
                this.action = action;
            }
        }
    }
}