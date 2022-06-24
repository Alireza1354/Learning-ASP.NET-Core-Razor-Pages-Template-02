using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
    public class IndexModel : Infrastructure.BasePageModel
    {



        public IndexModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;
        }

        private readonly Persistence.DatabaseContext _context;

        public System.Collections.Generic.IList
            <Domain.Account.Role> Roles
        { get; set; } = default!;

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
        {

            //ToListAsync  -> Microsoft.EntityFrameworkCore
            Roles = await _context.Role.ToListAsync();

            if (Roles == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
