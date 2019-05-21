using MyLife.ViewModels;
using MyLife.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyLife.Controls
{
    public static class AppInit
    {
        public static void Run(App context)
        {
            AppMap.StartedViewModel = new StartViewModel();

            AppMap.MasterViewModel = new MasterViewModel(AppMap.StartedViewModel);

            context.MainPage = AppMap.MasterViewModel.View;
        }
    }
}
