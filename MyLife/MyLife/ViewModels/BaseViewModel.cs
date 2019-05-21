using MyLife.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyLife.ViewModels
{
    public class BaseViewModel
    {
        private bool _isWasViewed = false;

        public virtual Page View { get; }

        public bool IsActivity;

        public BaseViewModel()
        {
            //InitViewModel();
        }

        public BaseViewModel(Page page)
        {
            View = page;
            InitViewModel();

            //page.BindingContext = this;
            //page.Appearing += LocalOnAppearing;
        }

        protected void InitViewModel()
        {
            View.BindingContext = this;
            View.Appearing += LocalOnAppearing;
        }

        private void LocalOnAppearing(object sender, EventArgs e)
        {
            IsActivity = true;
            OnAppearing();
            if (_isWasViewed == false)
            {
                _isWasViewed = true;
                OnFirstAppearing();
            }
        }

        public async Task NavigationTo(BaseViewModel vm)
        {
            await View.Navigation.PushAsync(vm.View);
        }

        public async Task NavigationToRoot()
        {
            await View.Navigation.PopToRootAsync();
        }

        public async Task Echo(string message)
        {
            await View.DisplayAlert(null, message, "OK");
        }

        protected virtual void OnAppearing()
        {
        }

        protected virtual void OnFirstAppearing()
        {

        }

        public virtual Task<bool> OnTryClosed()
        {
            return TaskHelper.FromResult(true);
        }
    }
}
