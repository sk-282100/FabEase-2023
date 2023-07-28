using FanEase.Entity.Models;
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
        public ActionResult AddCampaignss()
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

    }
}
