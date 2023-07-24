using Microsoft.AspNetCore.Mvc;

namespace FanEase.UI.Controllers
{
    public class TemplateController : Controller
    {
        public IActionResult AddTemplate()
        {
            return View();
        }
    }
}
