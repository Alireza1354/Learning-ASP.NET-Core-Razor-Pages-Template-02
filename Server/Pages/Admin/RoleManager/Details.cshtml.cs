using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Account;
using System.Threading.Tasks;
using System;

namespace Server.Pages.Admin.RoleManager
{
    public class DetailsModel : PageModel
    {

        private readonly Persistence.DatabaseContext _context;

        public DetailsModel(Persistence.DatabaseContext Context)
        {
            _context = Context;
        }

        public Role Role { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            var role = await _context.Role.FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                Role = role;
            }
            return Page();
        }
    }
}
