using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Campaign;
using FanEase.UI.Models.Campaign.Dto;
using FanEase.UI.Models.Template;
using FanEase.UI.Models.Videos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;
using System.Text;

namespace FanEase.UI.Controllers
{
    public class TemplateController : Controller
    {
        readonly IMapper _mapper;
        public TemplateController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> AddTemplate()
        {
            int? campaignId = HttpContext.Session.GetInt32("campaignId");

           // campaignId = 37;

            List<AdvertisemenetForTemp> advertisements = new List<AdvertisemenetForTemp>();
    
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7208/api/Advertisement/GetAdvertisementsofCampaign/{campaignId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    advertisements = JsonConvert.DeserializeObject<List<AdvertisemenetForTemp>>(data);
                }
            }

            ViewBag.Advertisements = advertisements;
            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTemplate(TemplateDetail templateDetail)
        {
            using (var httpclient = new HttpClient())
            {
                string userId = HttpContext.Session.GetString("UserId");
                int TemplateDetailsId; 
                var content = new StringContent(JsonConvert.SerializeObject(templateDetail), Encoding.UTF8, "application/json");
                    using (var response = await httpclient.PostAsync($"https://localhost:7208/api/TemplateDetails", content))
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                    }

                    using (var response = await httpclient.GetAsync($"https://localhost:7208/api/TemplateDetails/LatestAddedTemplateDetails/{userId}"))
                    {
                    string data = response.Content.ReadAsStringAsync().Result;
                    TemplateDetailsId = JsonConvert.DeserializeObject<ResponseModel<int>>(data).data;
                    }

                Templates templates = new Templates()
                {
                    TemplateId = 0,
                    TemplateDetailsId = TemplateDetailsId,
                    PublishStatus = false,
                    VideoStatus = true

                };
                var content1 = new StringContent(JsonConvert.SerializeObject(templates), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Template", content1))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }

                int TemplateId;

                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Template/LatestAddedTemplate/{userId}"))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    TemplateId = JsonConvert.DeserializeObject<ResponseModel<int>>(data).data;
                }

                int? VideoId = HttpContext.Session.GetInt32("videoId");
                if (VideoId == 0)
                    VideoId = null;
                if (VideoId != null)
                {
                    var content2 = new StringContent(JsonConvert.SerializeObject(new AssignTemplateVM { VideoId = VideoId, TemplateId = TemplateId }), Encoding.UTF8, "application/json");
                    using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Video/AssignTemplate", content2))
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                    }
                    HttpContext.Session.SetInt32("videoId", 0);
                    HttpContext.Session.SetInt32("campaignId", 0);

                    return RedirectToAction("VideoListByUSerId", "Video", new { userId = userId });
                }

                return RedirectToAction("GetAllTemplatesByUser", new { userId = userId });
            }

           

        }


            [HttpGet]
        [Route("GetAllTemplatesByUser/{userId}")]
        public async Task<IActionResult> GetAllTemplatesByUser(string userId)
        {
            ResponseModel<List<TemplateListVM>> responseModel = new ResponseModel<List<TemplateListVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Template/GetAllTemplatesByUser/{userId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<TemplateListVM>>>(data);
                }

            }
            List<TemplateListVM> TemplateList = _mapper.Map<List<TemplateListVM>>(responseModel.data);
            
            return View(TemplateList);
        }


        [HttpGet]
        [Route("GetAllTemplates")]
        public async Task<IActionResult> GetAllTemplates()
        {
            ResponseModel<List<TemplateListVM>> responseModel = new ResponseModel<List<TemplateListVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Template/GetAllTemplates"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<TemplateListVM>>>(data);
                }

            }
            List<TemplateListVM> TemplateList = _mapper.Map<List<TemplateListVM>>(responseModel.data);

            return View(TemplateList);
        }


        [HttpGet]
        public IActionResult UnderConstruction()
        {
            return View();
        }

        [HttpGet]
        [Route("RemoveTemplate/{templateId}")]
        public async Task<IActionResult> RemoveTemplate(int templateId)
        {
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.DeleteAsync($"https://localhost:7208/api/Template/{templateId}"))
                {

                    var UserId = HttpContext.Session.GetString("UserId");
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    if (HttpContext.Session.GetString("role") == "Admin")
                    {
                        return RedirectToAction("GetAllTemplates");
                    }
                    else
                    {
                        return RedirectToAction("GetAllTemplatesByUser", new { userId = UserId });
                    }


                }
            }
        }

    }

}
