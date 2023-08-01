﻿using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Campaign.Dto;
using FanEase.UI.Models.Creator;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FanEase.UI.Controllers
{
    public class CampaignController : Controller
    {
        [HttpGet]
        public ActionResult AddCampaign()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddCampaign(Campaignvm campaignvm)
        {

          //  string UserId = "RB6567";
           // campaignvm.userId = UserId;
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(campaignvm), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Campaign", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                return RedirectToAction("CampaignListScreenByUserId", new { userId = campaignvm.userId });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCampaignProceed(Campaignvm campaignvm)
        {
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(campaignvm), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Campaign", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                string userId=campaignvm.userId;
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
           // string UserId = "RB6567";
            //string UserId = HttpContext.Session.GetString("UserId");
           // userId = UserId;
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


        //[HttpGet]

        //public async Task<IActionResult> EditCampaign(string campaignId)
        //{

        //    CampaignListScreenVms campai;
        //        using (var httpclient = new HttpClient())
        //        {
        //            using (var response = await httpclient.GetAsync($"https://localhost:7208/api/User/{campaignId}"))
        //            {
        //                string data = await response.Content.ReadAsStringAsync();
        //                campai = JsonConvert.DeserializeObject<ResponseModel<CampaignListScreenVms>>(data).data;

        //            }
        //            return View(_mapper.Map<EditCreatorVM>(creator));
        //        }

        //    return RedirectToAction("CampaignListScreenByUserId", "Campaign");
        //}


        [HttpGet]
        public IActionResult UnderConstruction()
        {
            return View();
        }


    }
}
