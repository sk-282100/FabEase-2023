using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Creator;
using FanEase.UI.Models.Videos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FanEase.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        [HttpGet]
        public IActionResult AddAdvertisement()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddAdvertisement(Advertisement advertisement)
        {
            // Video video = _mapper.Map<Video>(addVideoVm);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(advertisement), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Advertisement", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                return RedirectToAction("UnderConstruction", "Home");
            }
        }



        [HttpGet]

        public async Task<IActionResult> AdvertisementList()
        {
            ResponseModel<List<AdvertisementListVM>> responseModel = new ResponseModel<List<AdvertisementListVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Advertisement/AdvertisementListScreen"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<AdvertisementListVM>>>(data);
                }

            }

            List<AdvertisementListVM> advertisements = new List<AdvertisementListVM>();
            return View(advertisements);
        }









    }
}
