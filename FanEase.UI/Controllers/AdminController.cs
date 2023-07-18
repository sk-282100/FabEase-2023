using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Creator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public IActionResult AddCreator()
       {
            return View();
       }
    
        [HttpPost]
        public async Task<IActionResult> AddCreator(AddCreatorVM creatorId) 
        {
            CreatorVM creator = new CreatorVM();
            Models.Creator.CredentialVM credentails = new Models.Creator.CredentialVM();
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
              if(creator!=null)
               credentails = new Models.Creator.CredentialVM()
                {
                    Email = creator.Email,
                    ContactNo = creator.ContactNo,
                    UserName = creator.UserName,
                    Password = creator.FirstName+"@123"

                    };
                    StringContent content = new StringContent(JsonConvert.SerializeObject(new Models.Creator.LoginDto { Email = credentails.Email,Password = credentails.Password }), Encoding.UTF8, "application/json");
                    using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Account/SetCreatorPassword", content))
                    {
                        string data = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction("SendCredentials",credentails);
        }

        [HttpPost]
        public async Task<IActionResult> SendCredentials(Models.Creator.CredentialVM credentials)
        {
            using (var httpclient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(new { @USERNAME = credentials.Email, @NEWPASSWORD = credentials.Password }), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/User/SetCreatorPassword", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    
                }
                content = new StringContent(JsonConvert.SerializeObject(credentials));
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/User/SendCredentials", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
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
                    advertisements = JsonConvert.DeserializeObject<List<Advertisement>>(data);
                    
                }
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Video/user/{creatorId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    videos = JsonConvert.DeserializeObject<List<Video>>(data);
                    
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
