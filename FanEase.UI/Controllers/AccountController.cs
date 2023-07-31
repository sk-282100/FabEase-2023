using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Creator;
using FanEase.UI.Models.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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
            //HttpContext.Session.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVm login)
        {
            HttpContext.Session.SetString("storedemail", login.Email);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Account/Login",content))
                {
                    try
                    {
                        string roles = "";
                        string? Password = "";
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
                            Password = jwtToken.Claims.FirstOrDefault(c => c.Type == "firstName")?.Value + "@123";
                            string? profilePhoto = "../"+jwtToken.Claims.FirstOrDefault(c => c.Type == "profilePhoto")?.Value.Replace("\\","/").Replace("..",".");
                            
                            // Store the token in a secure location, such as a cookie or session
                            HttpContext.Session.SetString("name", username1);
                            HttpContext.Session.SetString("UserId", UserId);
                            HttpContext.Session.SetString("role", roles);
                            HttpContext.Session.SetString("emailId", email);
                            HttpContext.Session.SetString("profilePhoto", profilePhoto);

                        }

                        if (roles == "Admin")
                        {
                            if (login.Password != Password)
                                return RedirectToAction("AdminDashboard", "Admin");
                            else
                                return RedirectToAction("SetPassword", "Account");
                        }
                        else if (roles == "Creator")
                        {
                            if (login.Password != Password)
                                return RedirectToAction("Index", "Home");
                            else
                                return RedirectToAction("SetPassword", "Account");
                        }
                        else if (roles == "Viewer")
                        {
                            if (login.Password != Password)
                                return RedirectToAction("UnderConstruction");
                            else
                                return RedirectToAction("SetPassword", "Account");
                        }
                        return RedirectToAction("Login");
                    }
                    catch
                    {
                        ViewBag.NotAllowed = "Invalid UserName or Password";
                        return View(login);
                    }

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
            User user = null;
            using (var httpclient = new HttpClient())
            {
                string email = emailVM.Email.Replace("@", "%40");
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/User/GetByUserName/{email}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<ResponseModel<User>>(data).data;
                }
            }
            if (user != null)
            {
                //Adding email to session
                HttpContext.Session.SetString("storedemail", emailVM.Email);
                ForgetPasswordVm psw = new ForgetPasswordVm();
                using (var httpclient = new HttpClient())
                {
                    // string change = emailVM.Email.Replace("@","%40");
                    using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Account/forgetPassword/{emailVM.Email}"))

                    {

                        string data = response.Content.ReadAsStringAsync().Result;
                        psw = JsonConvert.DeserializeObject<ForgetPasswordVm>(data);
                    }
                    return RedirectToAction("VerifyOTP");
                }
            }
            else
            {
                ViewBag.InvalidEmail = "! Not Registered Email ID Try Again With Registered Email";
                return View();
            }


        }

        [HttpGet("ResendOTP")]
        public IActionResult ResendOTP()
        {
            ForgetPasswordVm forgetPasswordVm = new ForgetPasswordVm();
          forgetPasswordVm.Email =  HttpContext.Session.GetString("storedemail");
            ViewBag.ErrorMessage = "Sent OTP agin to your MailID";
            return RedirectToAction("ForgetPassword", forgetPasswordVm);
        }


        [HttpGet("VerifyOTP")]
        
        public IActionResult VerifyOTP()
        {
            return View();
        }

        [HttpPost("VerifyOTP")]
        public async Task<ActionResult> VerifyOTP(VerifyOTPVm verifyOTPVm)
        {
            int otp = 0;
            string message = "test";
            VerifyOTPVm verifyOtp = new VerifyOTPVm();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Account/VerifyOTP?OTP={verifyOTPVm.OTP}"))
                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    otp = JsonConvert.DeserializeObject<ResponseModel<int>>(data).data;
                    message= JsonConvert.DeserializeObject<ResponseModel<int>>(data).message;
                }
                if (otp != 0)
                    return RedirectToAction("SetPassword");
                if(message== "timeout")
                {
                    ViewBag.ErrorMessage = "OTP Expired!!!";
                    return View();
                }

                    

                ViewBag.ErrorMessage = "Invalid OTP!!!";
                return View();
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
        [HttpGet("SetPassword")]

        public IActionResult SetPassword()
        {
            return View();
        }

        [HttpPost("SetPassword")]
        public async Task<IActionResult> SetPassword(Models.User.SetPasswordVm usernpassword)
        {
            

            using (var httpclient = new HttpClient())
            {
                var jsonContent = JsonConvert.SerializeObject(usernpassword);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
               
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Account/SetPassword", content))
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


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterVm viewer)
        {
            string imagePath = await SaveImageAsync(viewer.ProfilePhoto);
            if (imagePath.Contains(".jpg") || imagePath.Contains(".jpeg") || imagePath.Contains(".png"))
            {
                User user = new User()
                {
                    ProfilePhoto = imagePath,
                    FirstName = viewer.FirstName,
                    LastName = viewer.LastName,
                    VideoCount = 0,
                    Address = viewer.Address,
                    Country = viewer.Country,
                    City = viewer.City,
                    Email = viewer.Email,
                    ContactNo = viewer.ContactNo,
                    isActive = true,
                    CreationDate = DateTime.Now,
                    UserName = viewer.Email,
                    Password = viewer.FirstName + "@123"

                };

                using (var httpclient = new HttpClient())
                {
                    StringContent PostUser = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    using (var response = await httpclient.PostAsync($"https://localhost:7208/api/User", PostUser))
                    {

                        string data = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);
                        if (result.message == "Email Exists")
                        {
                            ViewBag.ErrorMessage = "Already Registered User with same Email Address try again";
                            return View();
                        }

                        if (result.message == "ContactNo Exists")
                        {
                            ViewBag.ErrorMessage = "Already Registered User with same Contact Number try again";
                            return View();
                        }

                        if (result.Succeed)
                        {
                            string userid = viewer.FirstName.Substring(0, 1) + viewer.LastName.Substring(0, 1) + viewer.ContactNo.Substring(viewer.ContactNo.Length - 4);
                            using (var response1 = await httpclient.GetAsync($"https://localhost:7208/api/User/AddViewer/{userid}"))
                            {
                                string data1 = response1.Content.ReadAsStringAsync().Result;

                            }

                            Entity.Models.CredentialVM credentails = new Entity.Models.CredentialVM();
                            credentails = new Entity.Models.CredentialVM()
                            {
                                Email = user.Email,
                                ContactNo = user.ContactNo,
                                UserName = user.UserName,
                                Password = user.Password

                            };
                            StringContent Credcontent = new StringContent(JsonConvert.SerializeObject(credentails), Encoding.UTF8, "application/json");
                            using (var resp = await httpclient.PostAsync($"https://localhost:7208/api/Account/SendCredentials", Credcontent))
                            {
                                string data1 = response.Content.ReadAsStringAsync().Result;

                            }
                            return RedirectToAction("Login");
                        }



                    }

                }

            }
            ViewBag.ErrorMessage = " only files with .jpg, .jpeg & .png are allowed";
            return View();
        }

        private async Task<string> SaveImageAsync(IFormFile image)
        {
            var uploadPath = Path.Combine("wwwroot", "UploadImage", "Creator");
            var imageName = Path.GetRandomFileName();
            var imageExtension = Path.GetExtension(image.FileName);

            var imagePath = Path.Combine(uploadPath, imageName + imageExtension);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return (Path.Combine("UploadImage", "Creator", imageName + "." + imageExtension));
        }



        [HttpGet]
        public IActionResult UnderConstruction()
        {
            return View();
        }



    }
}
