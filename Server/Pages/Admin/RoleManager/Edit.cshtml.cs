using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Server.Pages.Admin.RoleManager
{
    public class EditModel : Infrastructure.BasePageModel
    {

        private readonly Persistence.DatabaseContext _context;

        public EditModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public Domain.Account.Role Role { get; set; } = default!;

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            //FirstOrDefaultAsync -> Microsoft.EntityFrameworkCore
            var role = await _context.Role.FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            Role = role;
            return Page();
        }

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(Role.Id))
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

        private bool RoleExists(System.Guid id)
        {
            //Any -> System.Linq
            return (_context.Role?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
