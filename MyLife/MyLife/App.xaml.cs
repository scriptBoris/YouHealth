using MyLife.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyLife
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
#if DEBUG
            HotReloader.Current.Start(this, 8001);
#endif
            AppInit.Run(this);
            //MainPage = new NavigationPage()
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
