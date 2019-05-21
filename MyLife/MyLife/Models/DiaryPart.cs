using Microcharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyLife.Models
{
    public class DiaryPart : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string ImageSource { get; set; }
        public Chart Chart { get; set; }
        public List<FoodBundle> Bundles { get; set; }

        public DiaryPart(List<FoodBundle> bundles)
        {
            if (bundles == null) throw new NullReferenceException("List FoodBundle is null");
            if (bundles.Count == 0) throw new Exception("List FoodBundle is count equal 0");

            var entries = new Entry[bundles.Count];
            int i = 0;
            foreach (var item in bundles)
            {
                entries[i] = new Entry(item.Value)
                {
                    Color = item.Color,
                };
                i++;
            }

            Chart = new DonutChart() {
                Entries = entries,
                BackgroundColor = new SkiaSharp.SKColor(0,0,0,1)
            };
        }
    }
}
