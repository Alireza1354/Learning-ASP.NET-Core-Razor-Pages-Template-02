
namespace ViewModels.Pages.Admin.RoleManager
{
    public class RoleViewModel : object
    {
        public RoleViewModel() : base()
        {
            RoleName = "User Role";
        }

        // **********
        //[System.ComponentModel.DataAnnotations.Key]

        //[System.ComponentModel.DataAnnotations.Display
        //	(ResourceType = typeof(Resources.DataDictionary),
        //	Name = nameof(Resources.DataDictionary.Id))]

        //[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
        //	(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        //public System.Guid Id { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.InsertDateTime))]
        public System.DateTime InsertDateTime { get; private set; }
        // **********

        // **********
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
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
           (Name = nameof(Resources.DataDictionary.IsActive),
           ResourceType = typeof(Resources.DataDictionary))]

        public bool IsActive { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
           (Name = nameof(Resources.DataDictionary.IsDeletable),
           ResourceType = typeof(Resources.DataDictionary))]

        public bool IsDeletable { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
           (Name = nameof(Resources.DataDictionary.DefaultRole),
           ResourceType = typeof(Resources.DataDictionary))]

        public bool IsDefault { get; set; }
        // **********
    }
}
