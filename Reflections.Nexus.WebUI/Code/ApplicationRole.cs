using Microsoft.AspNetCore.Identity;

namespace Reflections.Nexus.WebUI.Code
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
