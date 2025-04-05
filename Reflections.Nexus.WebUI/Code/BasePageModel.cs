using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Reflections.Nexus.WebUI.Code
{
    //[Authorize]
    public class BasePageModel<T> : PageModel where T : BasePageModel<T>
    {

    }
}
