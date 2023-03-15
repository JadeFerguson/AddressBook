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
    public class IndexModel : PageModel
    {

        private readonly AddressBook.Data.ApplicationDbContext _context;

        public IndexModel(AddressBook.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserAddressBook> UserAddressBook { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserAddressBook != null)
            {
                UserAddressBook = await _context.UserAddressBook.ToListAsync();
            }
        }
    }
}
