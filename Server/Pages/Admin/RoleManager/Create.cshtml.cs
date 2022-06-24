
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

        public Microsoft.AspNetCore.Mvc.IActionResult OnGet()
        {
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
    }
}
