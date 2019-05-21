using MyLife.Core;
using MyLife.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyLife.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        public ICommand CommandTestButton { get; set; }

        public override Page View { get; } = new StartView();
        public StartViewModel()
        {
            CommandTestButton = new PageCommand(this, TestButton, false);
            InitViewModel();
        }

        private async void TestButton()
        {
            await Echo("Sample text");
        }
    }
}
