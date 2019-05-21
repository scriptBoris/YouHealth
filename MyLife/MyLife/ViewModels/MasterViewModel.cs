using MyLife.Controls;
using MyLife.Core;
using MyLife.Core.Extensions;
using MyLife.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyLife.ViewModels
{
    public class MasterViewModel
    {
        private BaseViewModel _startedVm;

        public readonly MasterView View = new MasterView();
        public ICommand CommandHome { get; set; }
        public ICommand CommandFoodDiary { get; set; }
        public ICommand CommandSettings { get; set; }
        public ICommand CommandAbout { get; set; }
        public ICommand CommandLogout { get; set; }

        // For intellisense
        public MasterViewModel() { }

        public MasterViewModel(BaseViewModel starterVm)
        {
            _startedVm = starterVm;

            CommandHome = new ContextCommand(Home);
            CommandFoodDiary = new ContextCommand(FoodDiary);

            View.Detail = new NavigationPage(starterVm.View);
            View.BindingContext = this;
        }

        private async void Home()
        {
            if (await CatchNavigation(AppMap.CurrentVm, typeof(StartViewModel)) == false)
                return;

            await _startedVm.NavigationToRoot();
        }

        private async void FoodDiary()
        {
            if (await CatchNavigation(AppMap.CurrentVm, typeof(FoodDiaryViewModel)) == false)
                return;

            await _startedVm.NavigationTo(new FoodDiaryViewModel() );
        }

        private async Task<bool> CatchNavigation(BaseViewModel vm, Type toVm)
        {
            View.IsPresented = false;

            if (vm.GetType() == toVm)
            {
                AppMap.CurrentVm.IsActivity = true;
                return false;
            }

            bool result = await vm.OnTryClosed();
            if (result == false)
                AppMap.CurrentVm.IsActivity = true;

            return result;
        }

    }
}
