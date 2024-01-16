using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class ChatHubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
