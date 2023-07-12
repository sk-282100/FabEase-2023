using AutoMapper;
using FanEase.UI.Models.Creator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

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

               credentails = new CredentialVM()
                {
                    Email = creator.Email,
                    ContactNo = creator.ContactNo,
                    UserName = creator.UserName,
                    Password = creator.Password

                };
            }

            return RedirectToAction("SendCredentials",credentails);
        }

        [HttpGet]
        public IActionResult SendCredentials(CredentialVM credentails) 
        {
            return View(credentails);
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
            
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/User/{creatorId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    creator = JsonConvert.DeserializeObject<CreatorVM>(data);
                }
            }
            return View(creator);
        }

        




    }
}
