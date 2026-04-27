using ilactakipsistem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ilactakipsistem.Controllers
{
    public class BaseController : Controller
    {
        protected readonly AppDbContext _context;

        public BaseController(AppDbContext context)
        {
            _context = context;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var profile = await _context.UserProfiles.FirstOrDefaultAsync();
            if (profile != null)
            {
                ViewBag.UserName = profile.UserName;
            }
            else
            {
                ViewBag.UserName = "Kullanıcı";
            }

            await next();
        }
    }
}
