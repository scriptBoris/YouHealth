using MyLife.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLife.Controls
{
    public static class AppMap
    {
        public static StartViewModel StartedViewModel { get; set; }

        public static MasterViewModel MasterViewModel { get; set; }

        public static BaseViewModel CurrentVm
        {
            get
            {
                int count = StartedViewModel.View.Navigation.NavigationStack.Count;
                var view = StartedViewModel.View.Navigation.NavigationStack[count - 1];
                return (BaseViewModel)view.BindingContext;
            }
        }
    }
}
