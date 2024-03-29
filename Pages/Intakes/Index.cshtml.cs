using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Calorie_Journal.Models;

namespace Calorie_Journal.Pages.Intakes
{
  public class IndexModel : PageModel
  {
    private readonly Calorie_Journal.Models.IntakeContext _context;

    public IndexModel(Calorie_Journal.Models.IntakeContext context)
    {
      _context = context;
    }

    public IList<Intake> Intake { get; set; }

    public async Task OnGetAsync()
    {
      var intakes = from i in _context.Intake select i;
      intakes = intakes.Where(i => i.DateTime.Date == DateTime.Today.Date);
      Intake = await intakes.Include(i => i.FoodEntry).ToListAsync();
    }
  }
}
