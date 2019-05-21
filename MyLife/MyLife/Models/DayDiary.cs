using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MyLife.Models
{
    public class DayDiary : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Day { get; set; }
        public ObservableCollection<DiaryPart> Parts { get; set; }
    }
}
