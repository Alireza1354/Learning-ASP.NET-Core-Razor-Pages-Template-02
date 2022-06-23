using Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Pages.Admin.RoleManager
{
    public class IndexModel : Infrastructure.BasePageModel
    {

        private readonly Persistence.DatabaseContext _context;

        public IndexModel(Persistence.DatabaseContext Context)
        {
            _context = Context;
            Roles = new()
            {
                new Role(){}
            };
        }

        public List<Role> Roles { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            //Roles = new List<Role>()
            //{
            //    new Role() 
            //    {
            //        Id = System.Guid.NewGuid(),
            //        RoleName = "Admin" 
            //    },
            //    new Role()
            //    {
            //        Id = System.Guid.NewGuid(),
            //        RoleName = "User"
            //    },
            //    new Role()
            //    {
            //        Id = System.Guid.NewGuid(),
            //        RoleName = "Guest"
            //    },
            //};
        


            Roles = await _context.Role.ToListAsync();

            if (Roles == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
