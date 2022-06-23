using Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Server.Pages.Admin.RoleManager
{
    public class CreateModel : Infrastructure.BasePageModel
    {

        private readonly Persistence.DatabaseContext _context;

        public CreateModel(Persistence.DatabaseContext Context)
        {
            _context = Context;
            Role = new();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Role Role { get; set; }

        public async Task<IActionResult> OnPostAsync()
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
