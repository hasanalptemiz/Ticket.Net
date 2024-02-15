using Microsoft.AspNetCore.Mvc;

namespace Ticket.Net.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}