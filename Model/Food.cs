using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calorie_Journal.Models
{
  public class Food
  {
    public int ID { get; set; }

    //Change dislay name
    public string Name { get; set; }
    //Change display name
    public decimal Serving { get; set; }
    public decimal Calories { get; set; }
    public decimal Carbs { get; set; }
  }
}