using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Calorie_Journal.Models;

namespace Calorie_Journal.Pages.Intakes
{
    public class CreateModel : PageModel
    {
        private readonly Calorie_Journal.Models.IntakeContext _context;

        public CreateModel(Calorie_Journal.Models.IntakeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FoodID"] = new SelectList(_context.Set<Food>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Intake Intake { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Intake.Add(Intake);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}