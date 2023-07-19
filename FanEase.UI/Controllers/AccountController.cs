using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Creator;
using FanEase.UI.Models.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FanEase.UI.Controllers
{
    public class AccountController : Controller
    {
        // [Route("Login")]
        [HttpGet]
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVm login)
        {
            
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Account/Login",content))
                {
                    string roles="";
                    if (response.IsSuccessStatusCode)
                    {
                        // Handle successful login, e.g., store authentication token
                        string result = await response.Content.ReadAsStringAsync();
                        string token = JsonConvert.DeserializeObject<ResponseModel<AuthResponse>>(result).data.Token;
                        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                        JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);
                        string? username1 = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                        string? email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                        string? UserId = jwtToken.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
                        roles = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                        // Store the token in a secure location, such as a cookie or session
                        HttpContext.Session.SetString("name", username1);
                        HttpContext.Session.SetString("UserId", UserId);
                        HttpContext.Session.SetString("role", roles);

                    }

                    if (roles == "Admin")
                    {
                        return RedirectToAction("ContenetCreatorList", "Admin");
                    }
                    else if (roles == "Creator")
                    {
                        return RedirectToAction("ContenetCreatorList", "Admin");
                    }
                    return RedirectToAction("Login");

                }
                
            }


        }




        [HttpGet("forgetpassword")]
        
        public IActionResult ForgetPassword() 
        {
            return View();
        }


        [HttpPost]
        [Route("forgetpassword")]
        public async Task<ActionResult> ForgetPassword(ForgetPasswordVm emailVM)
        {
            ForgetPasswordVm psw = new ForgetPasswordVm();
            using (var httpclient = new HttpClient())
            {
               // string change = emailVM.Email.Replace("@","%40");
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Account/forgetPassword/{emailVM.Email}" ))

                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    psw = JsonConvert.DeserializeObject<ForgetPasswordVm>(data);
                }
                return RedirectToAction("VerifyOTP");
            }

          
        }


        [HttpGet("VerifyOTP")]
        
        public IActionResult VerifyOTP()
        {
            return View();
        }

        [HttpPost("VerifyOTP")]
        public async Task<ActionResult> VerifyOTP(int OTP)
        {

            VerifyOTPVm verifyOtp = new VerifyOTPVm();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Account/VerifyOTP/{OTP}"))
                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    verifyOtp = JsonConvert.DeserializeObject<VerifyOTPVm>(data);
                }
                return RedirectToAction("ResetPassword");
            }


           

        }

        [HttpGet("ResetPassword")]
        
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost("ResetPassword")]

        public async Task<ActionResult> ResetPassword(string OldPassword, string UserId, string NewPassword)
        {

            ResetPasswordVm resetPassword = new ResetPasswordVm();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Account"))
                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    resetPassword = JsonConvert.DeserializeObject<ResetPasswordVm>(data);
                }
                return RedirectToAction("Login");
            }

        }
        [HttpPost]
        public async Task<IActionResult> SetPassword(LoginVm usernpassword)
        {
            using (var httpclient = new HttpClient())
            {
                var content =new StringContent(JsonConvert.SerializeObject(usernpassword));
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Account/setPassword",content))
                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    
                }
                return RedirectToAction("Login");
            }
        }






        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }



    }
}
