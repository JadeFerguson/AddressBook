using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressBook.Data;
using AddressBook.Pages.Services;

namespace AddressBook.Pages
{
    public class EditModel : PageModel
    {
        private readonly AddressBook.Data.ApplicationDbContext _context;

        public EditModel(AddressBook.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserAddressBook UserAddressBook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserAddressBook == null)
            {
                return NotFound();
            }

            var useraddressbook =  await _context.UserAddressBook.FirstOrDefaultAsync(m => m.Id == id);
            if (useraddressbook == null)
            {
                return NotFound();
            }
            UserAddressBook = useraddressbook;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserAddressBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressBookExists(UserAddressBook.Id))
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

        private bool UserAddressBookExists(int id)
        {
          return _context.UserAddressBook.Any(e => e.Id == id);
        }
    }
}
