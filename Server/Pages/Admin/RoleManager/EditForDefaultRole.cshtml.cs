using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
    public class EditForDefaultRoleModel : PageModel
    {

        private readonly Persistence.DatabaseContext _context;

        public EditForDefaultRoleModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;
            RoleViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public System.Guid Id { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Admin.RoleManager.RoleViewModelForEditDefaultRole RoleViewModel { get; set; }


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

            RoleViewModel.RoleName = role.RoleName;

            return Page();
        }

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var roleToUpdate = await _context.Role.FindAsync(Id);

            if (roleToUpdate == null)
            {
                return Page();
            }

            if (await TryUpdateModelAsync<Domain.Account.Role>(
               roleToUpdate,
               "RoleViewModel",
               s => s.RoleName, s => s.IsActive, s => s.IsDefault, s => s.IsDeletable))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

    }
}
