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
    public class DetailsModel : PageModel
    {
        private readonly AddressBook.Data.ApplicationDbContext _context;

        public DetailsModel(AddressBook.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
