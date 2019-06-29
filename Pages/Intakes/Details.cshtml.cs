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
    public class DetailsModel : PageModel
    {
        private readonly Calorie_Journal.Models.IntakeContext _context;

        public DetailsModel(Calorie_Journal.Models.IntakeContext context)
        {
            _context = context;
        }

        public Intake Intake { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Intake = await _context.Intake
                .Include(i => i.FoodEntry).FirstOrDefaultAsync(m => m.ID == id);

            if (Intake == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
