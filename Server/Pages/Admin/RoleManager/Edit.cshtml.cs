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
            RoleViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public System.Guid Id { get; set; }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Admin.RoleManager.RoleViewModel RoleViewModel { get; set; }

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

            if (true)
            {

            }

            RoleViewModel.RoleName = role.RoleName;
            RoleViewModel.IsDefault = role.IsDefault;
            RoleViewModel.IsDeletable = role.IsDeletable;
            RoleViewModel.IsActive = role.IsActive;

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
            //************************************************************
            //_context.Attach(RoleViewModel).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RoleExists(Role.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");

            //*****************************************************
        }

        //private bool RoleExists(System.Guid id)
        //{
        //    //Any -> System.Linq
        //    return (_context.Role?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
