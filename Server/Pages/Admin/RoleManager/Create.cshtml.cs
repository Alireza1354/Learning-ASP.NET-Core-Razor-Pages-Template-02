
using System.Linq;

namespace Server.Pages.Admin.RoleManager
{
    public class CreateModel : Infrastructure.BasePageModel
    {

        public CreateModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;

            Role = new();
        }

        private readonly Persistence.DatabaseContext _context;

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public Domain.Account.Role Role { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public string DefaultUserDefined { get; set; }

        public Microsoft.AspNetCore.Mvc.IActionResult OnGet()
        {
            if (DefaultRoleExists())
            {

            }
            return Page();
        }

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            _context.Role.Add(Role);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool DefaultRoleExists()
        {
            //Any -> System.Linq
            return (_context.Role?.Any(e => e.IsDefault == true)).GetValueOrDefault();
        }
    }
}
