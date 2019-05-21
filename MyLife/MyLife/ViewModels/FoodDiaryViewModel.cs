using MyLife.Models;
using MyLife.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MyLife.ViewModels
{
    public class FoodDiaryViewModel : BaseViewModel
    {
        public ObservableCollection<DayDiary> Days { get; set; }
        public override Page View { get; } = new FoodDiaryView();

        public FoodDiaryViewModel()
        {
            InitViewModel();
        }
    }
}
