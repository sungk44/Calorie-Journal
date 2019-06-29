using Microsoft.EntityFrameworkCore;

namespace Calorie_Journal.Models
{
  public class IntakeContext : DbContext
  {
    public IntakeContext(DbContextOptions<IntakeContext> options) : base(options)
    {

    }

    public DbSet<Calorie_Journal.Models.Intake> Intake { get; set; }
  }
}