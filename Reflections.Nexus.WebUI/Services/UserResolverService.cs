//using Reflections.Framework.RoleBasedSecurity.Extensions;
using System;
using System.Security.Claims;

namespace Reflections.Nexus.WebUI.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public int GetCurrentUserID()
        {
            if (_context.HttpContext.User.Identity.IsAuthenticated)
            {
                //return _context.HttpContext.User.Identity.Name;
                return int.Parse(_context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }
            else
            {
                return 0;
            }
        }

        ////public int GetBusinessUnitId()
        ////{
        ////    if (_context.HttpContext.User.Identity.IsAuthenticated)
        ////    {
        ////        return _context.HttpContext.User.Identity.BusinessUnitId();
        ////    }
        ////    else
        ////    {
        ////        return 0;
        ////    }
        ////}
    }
}
