using Microsoft.AspNetCore.Mvc;

namespace FanEase.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [Route("forgetpassword")]
        public IActionResult ForgetPassword() 
        {
            return View();
        }

        [Route("VerifyOTP")]
        public IActionResult VerifyOTP()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}
