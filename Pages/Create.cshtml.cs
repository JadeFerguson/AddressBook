using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddressBook.Data;
using AddressBook.Pages.Services;

namespace AddressBook.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AddressBook.Data.ApplicationDbContext _context;

        public CreateModel(AddressBook.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserAddressBook UserAddressBook { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserAddressBook.Add(UserAddressBook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
