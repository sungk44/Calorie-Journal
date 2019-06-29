using System;
using System.ComponentModel.DataAnnotations;

namespace Calorie_Journal.Models
{
    public class Intake
    {
        public int ID { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public decimal Quantity { get; set; }

        [Display(Name = "Food")]
        public int FoodID { get; set; }

        [Display(Name = "Food")]
        public Food FoodEntry { get; set; }
    }
}