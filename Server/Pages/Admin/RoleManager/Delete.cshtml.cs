using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Server.Pages.Admin.RoleManager
{
    public class DeleteModel : Infrastructure.BasePageModel
    {

        //Microsoft.Extensions.Logging ---> ILogger
        private readonly ILogger<DeleteModel> _logger;

        private readonly Persistence.DatabaseContext _context;

        public DeleteModel(Persistence.DatabaseContext Context, ILogger<DeleteModel> logger) : base()
        {
            _logger = logger;
            _context = Context;
            ErrorMessage = "";
            RoleViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public System.Guid Id { get; set; }

        public string ErrorMessage { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Admin.RoleManager.RoleViewModel RoleViewModel { get; set; }


        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id, bool? saveChangesError = false)
        {

            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            //FirstOrDefaultAsync -> using Microsoft.EntityFrameworkCore;
            var role = await _context.Role
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (role == null)
            {
                return NotFound();
            }
            else
            {
                RoleViewModel.RoleName = role.RoleName;
                RoleViewModel.IsActive = role.IsActive;
                RoleViewModel.IsDefault = role.IsDefault;
                RoleViewModel.IsDeletable = role.IsDeletable;
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = System.String.Format("Delete {ID} failed. Try again", id);
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
            if (role == null)
            {
                return NotFound();
            }

            try
            {
                _context.Role.Remove(role);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { Id, saveChangesError = true });
            }

        }
    }
}