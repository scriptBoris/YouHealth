using MyLife.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLife.Models
{
    public class ConfigModel
    {
        public string ServerConnect { get; set; } = "http://helicat.ru/youhealth/";
        public FoodDiaryMode FoodDiaryDefault { get; set; }
    }
}
