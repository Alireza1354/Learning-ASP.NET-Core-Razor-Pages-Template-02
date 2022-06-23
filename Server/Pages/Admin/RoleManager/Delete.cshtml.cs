using Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Server.Pages.Admin.RoleManager
{
    public class DeleteModel : Infrastructure.BasePageModel
    {

        private readonly Persistence.DatabaseContext _context;

        public DeleteModel(Persistence.DatabaseContext Context)
        {
            _context = Context;
            Role = new();
        }


        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }
            var role = await _context.Role.FindAsync(id);

            if (role != null)
            {
                Role = role;
                _context.Role.Remove(Role);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
