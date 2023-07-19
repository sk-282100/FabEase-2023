﻿using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Creator;
using FanEase.UI.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;
using System.Text;

namespace FanEase.UI.Controllers
{
    public class AdminController : Controller
    {

        readonly IMapper _mapper;
        public AdminController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AddCreatorForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCreatorForm(AddCreatorFormDTO creator)
        {
            string imagePath = await SaveImageAsync(creator.ProfilePhoto);
            User user = new User()
            {
                ProfilePhoto = imagePath,
                FirstName = creator.FirstName,
                LastName = creator.LastName,
                VideoCount=0,
                Address=creator.Address,
                Country=creator.Country,
                City=creator.City,
                Email=creator.Email,
                ContactNo=creator.ContactNo,
                isActive=true,
                CreationDate=DateTime.Now,
                UserName=creator.Email,
                Password=creator.FirstName+"@123"

            };
            using (var httpclient = new HttpClient())
            {
                StringContent PostUser = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/User",PostUser))
                {
                    
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);
                    if (result.Succeed)
                    {
                        string userid = creator.FirstName.Substring(0,1) + creator.LastName.Substring(0,1) + creator.ContactNo.Substring(creator.ContactNo.Length - 4);
                        using (var response1 = await httpclient.GetAsync($"https://localhost:7208/api/User/AddCreator/{userid}"))
                        {
                            string data1 = response.Content.ReadAsStringAsync().Result;

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
                        return RedirectToAction("ContenetCreatorList");
                    }

                  return  RedirectToAction("AddCreatorForm");

                }
                
            }
            
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

            return (Path.Combine("UploadImage", "Creator", imageName+"."+imageExtension));
        }


        [HttpGet]
        public IActionResult AddCreator()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCreator(AddCreatorVM creatorId)
        {
            CreatorVM creator = new CreatorVM();
            Entity.Models.CredentialVM credentails = new Entity.Models.CredentialVM();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/User/{creatorId.UserId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    creator = JsonConvert.DeserializeObject<ResponseModel<CreatorVM>>(data).data;

                }

                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/User/AddCreator/{creatorId.UserId}"))
                {
                    string data = response.Content.ReadAsStringAsync().Result;

                }
                if (creator != null)
                {
                    credentails = new Entity.Models.CredentialVM()
                    {
                        Email = creator.Email,
                        ContactNo = creator.ContactNo,
                        UserName = creator.UserName,
                        Password = creator.FirstName + "@123"

                    };
                    StringContent content = new StringContent(JsonConvert.SerializeObject(new Models.Creator.LoginDto { Email = credentails.Email, Password = credentails.Password }), Encoding.UTF8, "application/json");
                    using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Account/SetCreatorPassword", content))
                    {
                        string data = response.Content.ReadAsStringAsync().Result;

                    }
                    StringContent Credcontent = new StringContent(JsonConvert.SerializeObject(credentails), Encoding.UTF8, "application/json");
                    using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Account/SendCredentials", Credcontent))
                    {
                        string data = response.Content.ReadAsStringAsync().Result;

                    }
                    return RedirectToAction("ContenetCreatorList");
                }
            }

            return RedirectToAction("AddCreator");
        }



        [HttpGet]
        public async Task<IActionResult> ContenetCreatorList()
        {
            ResponseModel<List<CreatorVM>> responseModel = new ResponseModel<List<CreatorVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/creatorlist"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<CreatorVM>>>(data);
                }

            }
            List<CreatorListVM> CreatorVMList = _mapper.Map<List<CreatorListVM>>(responseModel.data);
            return View(CreatorVMList);
        }

        [HttpGet]
        [Route("{creatorId}")]
        public async Task<IActionResult> CreatorDetails(string creatorId)
        {
            CreatorVM creator;
            List<Advertisement> advertisements;
            List<Video> videos;

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/User/{creatorId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    creator = JsonConvert.DeserializeObject<ResponseModel<CreatorVM>>(data).data;

                }
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Advertisement/user/{creatorId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    try
                    {
                        advertisements = JsonConvert.DeserializeObject<List<Advertisement>>(data);
                    }
                    catch
                    {
                        advertisements=new List<Advertisement>();
                    }
                }
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Video/user/{creatorId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    try
                    {
                        videos = JsonConvert.DeserializeObject<List<Video>>(data);
                    }
                    catch
                    {
                        videos =new List<Video>();
                    }

                }

            }

            return View(new CreatorDetailsVM()
            {
                Creator = creator,
                Videos = videos,
                Advertisements = advertisements
            });

            //return View(creator);
        }






    }
}
