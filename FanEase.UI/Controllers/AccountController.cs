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

        [HttpGet]
        public IActionResult ForgetPassword() 
        {
            
        }



        [Route("VerifyOTP")]
        public IActionResult VerifyOTP()
        {
            return View();
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("ResetPassword")]
        public IActionResult ResetPassword() 
        {
            return View();
        }

    }
}
