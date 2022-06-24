using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
    public class DetailsModel : Infrastructure.BasePageModel
    {

        private readonly Persistence.DatabaseContext _context;

        public DetailsModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;
        }

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
            else
            {
                Role = role;
            }
            return Page();
        }
    }
}
