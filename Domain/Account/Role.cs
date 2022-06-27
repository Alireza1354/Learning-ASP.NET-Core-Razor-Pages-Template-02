using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Account
{
    public class Role : SeedWork.Entity, SeedWork.IEntityHasIsActive, SeedWork.IEntityHasIsDeletable
    {

        public Role() : base()
        {
            RoleName = "User Role";
            IsDeletable = true;
            IsDefault = false;
        }

        // **********
        public string RoleName { get; set; }
        // **********

        // **********
        public bool IsActive { get; set; }
        // **********

        // **********
        public bool IsDeletable { get; set; }
        // **********

        // **********
        public bool IsDefault { get; set; }
        // **********
    }
}
