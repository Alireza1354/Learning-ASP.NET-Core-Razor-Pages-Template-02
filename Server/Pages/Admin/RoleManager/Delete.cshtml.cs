using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
    public class DeleteModel : Infrastructure.BasePageModel
    {

        public DeleteModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;

            Role = new();
        }

        private readonly Persistence.DatabaseContext _context;


        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/default
        [Microsoft.AspNetCore.Mvc.BindProperty]
        public Domain.Account.Role Role { get; set; } = default!;

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
        {

            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            //FirstOrDefaultAsync -> using Microsoft.EntityFrameworkCore;
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

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnPostDeleteAsync(System.Guid? Id)
        {

            if (Id == null || _context.Role == null)
            {
                return NotFound();
            }

            var role = await _context.Role.FindAsync(Id);
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
