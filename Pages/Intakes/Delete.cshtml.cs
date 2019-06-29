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
    public class DeleteModel : PageModel
    {
        private readonly Calorie_Journal.Models.IntakeContext _context;

        public DeleteModel(Calorie_Journal.Models.IntakeContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Intake = await _context.Intake.FindAsync(id);

            if (Intake != null)
            {
                _context.Intake.Remove(Intake);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
