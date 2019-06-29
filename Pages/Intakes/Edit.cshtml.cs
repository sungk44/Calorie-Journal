using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Calorie_Journal.Models;

namespace Calorie_Journal.Pages.Intakes
{
    public class EditModel : PageModel
    {
        private readonly Calorie_Journal.Models.IntakeContext _context;

        public EditModel(Calorie_Journal.Models.IntakeContext context)
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
           ViewData["FoodID"] = new SelectList(_context.Set<Food>(), "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Intake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntakeExists(Intake.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IntakeExists(int id)
        {
            return _context.Intake.Any(e => e.ID == id);
        }
    }
}
