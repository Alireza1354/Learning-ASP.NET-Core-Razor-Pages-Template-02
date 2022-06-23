using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Account
{
    public class Role: SeedWork.Entity
    {
        public Role()
        {
            RoleName = "User Role";
        }

        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.RoleName),
            ResourceType = typeof(Resources.DataDictionary))]

        [System.ComponentModel.DataAnnotations.Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

        [System.ComponentModel.DataAnnotations.MaxLength
            (length: Domain.SeedWork.Constant.MaxLength.Username,
            ErrorMessageResourceType = typeof(Resources.Messages.Validations),
            ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

        public string RoleName { get; set; }
    }
}
