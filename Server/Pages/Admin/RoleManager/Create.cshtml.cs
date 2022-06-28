using Domain.Account;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
    public class CreateModel : Infrastructure.BasePageModel
    {

        public CreateModel(Persistence.DatabaseContext Context) : base()
        {
            _context = Context;

            RoleViewModel = new();
            ErrorMessage = "";
            DefaultRoleName = "";
            DefaultRoleValue = "";
        }

        private readonly Persistence.DatabaseContext _context;

        public string ErrorMessage { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public string DefaultRoleName { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public string DefaultRoleValue { get; set; }


        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Admin.RoleManager.RoleViewModel RoleViewModel { get; set; }

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGet()
        {

            var role = await _context.Role.FirstOrDefaultAsync(e => e.IsDefault == true);
            if (role != null)
            {
                DefaultRoleName = role.RoleName;
            }

            return Page();
        }

        public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //https://docs.microsoft.com/en-gb/aspnet/core/data/ef-rp/crud?view=aspnetcore-6.0

            var role = _context.Add(new Role());

            if (DefaultRoleValue == "IsDefaultRole")
            {
                RoleViewModel.IsDefault = true;
            }
            else
            {
                RoleViewModel.IsDeletable = true;
            }

            role.CurrentValues.SetValues(RoleViewModel);

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
