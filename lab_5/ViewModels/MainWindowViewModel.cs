using System;
using System.Collections.Generic;
using System.Text;
using lab_5.Views;
using ReactiveUI;
using lab_5.ViewModels;
using lab_5.Models;

namespace lab_5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string text = "";

        private string reg = "";

        private string res = "";

        public string Text
        {
            get => text;
            set => this.RaiseAndSetIfChanged(ref text, value);
        }

        public string Regular
        {
            get => reg;
            set => this.RaiseAndSetIfChanged(ref reg, value);
        }

        public string Result
        {
            get => res;
            set => this.RaiseAndSetIfChanged(ref res, value);
        }

        public string FindRegex() => RegexLogic.FindRegexInText(text, reg);
    }
}
