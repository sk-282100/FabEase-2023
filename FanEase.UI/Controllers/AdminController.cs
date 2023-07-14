using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models.Creator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
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
            CredentialVM credentails = new CredentialVM();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/User/{creatorId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    creator = JsonConvert.DeserializeObject<CreatorVM>(data);
                
                }
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/UserRoles/AddCreator/{creatorId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    
                }
              if(creator!=null)
               credentails = new CredentialVM()
                {
                    Email = creator.Email,
                    ContactNo = creator.ContactNo,
                    UserName = creator.UserName,
                    Password = creator.FirstName+"@123"

                };
            }

            return RedirectToAction("SendCredentials",credentails);
        }

        [HttpPost]
        public async Task<IActionResult> SendCredentials(CredentialVM credentials)
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
        }
       

        [HttpGet]
        public async Task<IActionResult> ContenetCreatorList()
        {
            List<CreatorVM> creatorList = new List<CreatorVM>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/User"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    creatorList = JsonConvert.DeserializeObject<List<CreatorVM>>(data);
                }

            }
            List<CreatorListVM> CreatorVMList = _mapper.Map<List<CreatorListVM>>(creatorList);
            return View(CreatorVMList);
        }

        [HttpPut]
        public async Task<IActionResult> CreatorDetails(string creatorId)
        {
            CreatorVM creator = new CreatorVM();
            List<Advertisement> advertisements = new List<Advertisement>();
            List<Video> videos = new List<Video>();
            
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/User/{creatorId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    creator = JsonConvert.DeserializeObject<CreatorVM>(data);

                }
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Advertisement/user/{creatorId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    advertisements = JsonConvert.DeserializeObject<List<Advertisement>>(data);
                }
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/videos/user/{creatorId}"))
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
