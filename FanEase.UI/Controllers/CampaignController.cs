using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Advertisements;
using FanEase.UI.Models.Campaign;
using FanEase.UI.Models.Campaign.Dto;
using FanEase.UI.Models.Creator;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FanEase.UI.Controllers
{
    public class CampaignController : Controller
    {
        readonly IMapper _mapper;

        public CampaignController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CampaignDetails(string CampaignId)
        {

            MainCampaignUI campaign;

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Campaign/GetById?campaignId={CampaignId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    campaign = JsonConvert.DeserializeObject<ResponseModel<MainCampaignUI>>(data).data;

                }

            }
            return View(campaign);
        }
        [HttpGet]
        public async Task<ActionResult> AddCampaign()
        {
            string userId = HttpContext.Session.GetString("UserId");
            List<AdvertisementListVM> advertisements = new List<AdvertisementListVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7208/api/Advertisement/GetAdvertisementsByUser/{userId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    advertisements = JsonConvert.DeserializeObject<List<AdvertisementListVM>>(data);
                }
            }
            ViewBag.Advertisements = _mapper.Map<List<SelectAdvertisement>>(advertisements);
            CampaignWithAdsDTO campaignWithAdsDTO = new CampaignWithAdsDTO();
            campaignWithAdsDTO.Advertisements = new List<SelectAdvertisement>();
            return View(campaignWithAdsDTO);
        }
        [HttpPost]
        public async Task<ActionResult> AddCampaign(CampaignWithAdsDTO campaignWithAdsDTO)
        {
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(campaignWithAdsDTO.Campaign), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Campaign", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                return RedirectToAction("CampaignListScreenByUserId", new { userId = campaignWithAdsDTO.Campaign.userId });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCampaignProceed(CampaignWithAdsDTO campaignWithAdsDTO)
        {
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(campaignWithAdsDTO.Campaign), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Campaign", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                string userId=campaignWithAdsDTO.Campaign.userId;
                int CampaignId;
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Campaign/LatestAddedCampaign/{userId}"))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    CampaignId = JsonConvert.DeserializeObject<ResponseModel<int>>(data).data;
                }
                HttpContext.Session.SetInt32("campaignId", CampaignId);
                int? VideoId = HttpContext.Session.GetInt32("videoId");

                var content1 = new StringContent(JsonConvert.SerializeObject(new AssignCampaignVM{VideoId=VideoId,CampaignId=CampaignId}), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Video/AssignCampaign", content1))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }

                return RedirectToAction("AddAdvertisement", "Advertisement");
            }
        }


        [HttpGet]
        public async Task<IActionResult> CampaignListScreenByUserId(string userId)
        {
            string UserId = HttpContext.Session.GetString("UserId");
            List<CampaignListScreenVms> Campaign = new List<CampaignListScreenVms>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7208/api/Campaign/GetAllCampaignListScreenByUserId/userId?userId={userId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Campaign = JsonConvert.DeserializeObject<ResponseModel<List<CampaignListScreenVms>>>(data).data;
                }
            }

            return View(Campaign);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCampaign(string campaignId)
        {
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.DeleteAsync($"https://localhost:7208/api/Campaign?campaignId={campaignId}"))
                {

                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);
                    string UserId = HttpContext.Session.GetString("UserId");

                    return RedirectToAction("CampaignListScreenByUserId", new { userId = UserId });
                }
            }
        }


        [HttpGet]
        //[Route("EditCampaign/{CampaignId}")]

        public async Task<IActionResult> EditCampaigns(int CampaignId)
        {

            MainCampaignUI campaign;

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Campaign/GetById?campaignId={CampaignId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    campaign = JsonConvert.DeserializeObject<ResponseModel<MainCampaignUI>>(data).data;

                }

            }
            return View(campaign);

        }
        /// <summary>
        /// EditCampaignsDetails  for only campaign
        /// </summary>
        /// <param name="CampaignId"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<IActionResult> EditCampaignsDetails(int CampaignId)
        {

            MainCampaignUI campaign;
            EditCampaign editCampaign=new EditCampaign();       

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Campaign/GetById?campaignId={CampaignId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    campaign = JsonConvert.DeserializeObject<ResponseModel<MainCampaignUI>>(data).data;
                    editCampaign.campaignId = campaign.campad.CampaignId;
                    editCampaign.name = campaign.campad.name;
                    editCampaign.startDate = campaign.campad.startDate;
                    editCampaign.endDate = campaign.campad.endDate;
                    editCampaign.userId = campaign.campad.userId;


                }

            }
            return View(editCampaign);

        }



        [HttpPost]

        public async Task<IActionResult> EditCampaignsDetails(EditCampaign editCampaign)
        {


            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(editCampaign), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PutAsync($"https://localhost:7208/api/Campaign", content))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("CampaignListScreenByUserId", new { userId = editCampaign.userId });

                }

            }
        }


        //[HttpGet]
        ////[Route("EditCampaign/{CampaignId}")]

        //public async Task<IActionResult> EditCampaigns(int CampaignId)
        //{

        //    EditCampaign editCampaign;
        //    using (var httpclient = new HttpClient())
        //    {
        //        using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Campaign/EditGetAllCampaignAdv/CampaignId?CampaignId={CampaignId}"))
        //        {
        //            string data = await response.Content.ReadAsStringAsync();
        //            editCampaign = JsonConvert.DeserializeObject<ResponseModel<EditCampaign>>(data).data;

        //        }

        //        return View(editCampaign);

        //    }

        //}

        //[HttpPost]

        //public async Task<IActionResult> EditCampaignPost(EditCampaign editCampaign)
        //{


        //    using (var httpclient = new HttpClient())
        //    {
        //        var content = new StringContent(JsonConvert.SerializeObject(editCampaign), Encoding.UTF8, "application/json");
        //        using (var response = await httpclient.PutAsync($"https://localhost:7208/api/Advertisement/EditAdvertisement", content))
        //        {
        //            string data = await response.Content.ReadAsStringAsync();
        //            var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

        //            return RedirectToAction("CampaignListScreenByUserId");

        //        }

        //    }
        //}

        [HttpGet]
        public IActionResult UnderConstruction()
        {
            return View();
        }


    }
}
