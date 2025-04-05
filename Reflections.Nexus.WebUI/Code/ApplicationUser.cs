using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflections.Nexus.WebUI.Code
{
    public class ApplicationUser : IdentityUser<int>
    {
        [PersonalData]
        [StringLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string FirstName { get; set; }

        [PersonalData]
        [StringLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string LastName { get; set; }

        [NotMapped]
        public string DisplayName {
            get { return FirstName + " " + LastName; }
        } 

        public bool IsActive { get; set; }
    }
}
