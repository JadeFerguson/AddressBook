using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddressBook.Data;
using AddressBook.Pages.Services;

namespace AddressBook.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly AddressBook.Data.ApplicationDbContext _context;

        public DeleteModel(AddressBook.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserAddressBook UserAddressBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserAddressBook == null)
            {
                return NotFound();
            }

            var useraddressbook = await _context.UserAddressBook.FirstOrDefaultAsync(m => m.Id == id);

            if (useraddressbook == null)
            {
                return NotFound();
            }
            else 
            {
                UserAddressBook = useraddressbook;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserAddressBook == null)
            {
                return NotFound();
            }
            var useraddressbook = await _context.UserAddressBook.FindAsync(id);

            if (useraddressbook != null)
            {
                UserAddressBook = useraddressbook;
                _context.UserAddressBook.Remove(UserAddressBook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
