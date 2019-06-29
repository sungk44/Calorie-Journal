using Microsoft.EntityFrameworkCore;

namespace Calorie_Journal.Models
{
  public class FoodContext : DbContext
  {
    public FoodContext(DbContextOptions<FoodContext> options) : base(options)
    {

    }

    public DbSet<Calorie_Journal.Models.Food> Food { get; set; }
  }
}