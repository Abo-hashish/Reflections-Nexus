using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Reflections.Nexus.WebUI.Code;
using Reflections.Nexus.WebUI.Services;
        using Reflections.Nexus.WebUI.Data;
        using M=Reflections.Nexus.WebUI.Models;

namespace Reflections.Nexus.WebUI.Pages.JobType
{
    [Authorize(Roles = "Administrator,Configuration")]
    public class CreateModel : BasePageModel<CreateModel>
    {
    private readonly Reflections.Nexus.WebUI.Data.ApplicationDbContext _context;
    private readonly UserResolverService _userService;

    public CreateModel(Reflections.Nexus.WebUI.Data.ApplicationDbContext context, UserResolverService userService)
    {
    _context = context;
    _userService = userService;
    }

    public IActionResult OnGet()
    {
    return Page();
    }

    [BindProperty]
    public M.JobType JobType { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult>
        OnPostAsync()
        {

        //var User = _context.Users.FirstOrDefault(u => u.Id == _userService.GetCurrentUserID());

        //JobType.Created = DateTime.Now;
        //JobType.CreatedBy = User.Id;
        //JobType.Updated = DateTime.Now;
        //JobType.UpdatedBy = User.Id;

        if (!ModelState.IsValid)
        {
        return Page();
        }

        _context.JobTypes.Add(JobType);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
        }
        }
        }
