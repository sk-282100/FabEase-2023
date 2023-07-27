using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Campaign.Dto;
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
        public async Task<ActionResult> AddCampaignss(Campaignvm campaignvm)
        {

            string UserId = "AT10";
            campaignvm.userId = UserId;
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(campaignvm), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Campaign", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                return RedirectToAction("CampaignListScreenByUserId", "Campaign");
            }
        }



        [HttpGet]
        public async Task<IActionResult> CampaignListScreenByUserId(string userId)
        {
            string UserId = "AT10";
            //string UserId = HttpContext.Session.GetString("UserId");
            userId = UserId;
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


    }
}
