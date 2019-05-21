using MyLife.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyLife.Core.Extensions
{
    public static class ViewExtenseion
    {
        public static BaseViewModel GetBaseViewModel(this Page view)
        {
            var res = view.BindingContext;

            if (res == null) throw new Exception("Page without binding context");

            if (res is BaseViewModel == false) throw new Exception("Page binding context not a BaseViewModel");

            return (BaseViewModel) res;
        }
    }
}
