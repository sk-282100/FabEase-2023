using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Creator;
using FanEase.UI.Models.Videos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FanEase.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        readonly IMapper _mapper;
        bool flag;
        public AdvertisementController(IMapper mapper)
        {
            mapper = _mapper;
        }
        [HttpGet]
        public IActionResult AddAdvertisement()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddAdvertisement(Advertisement advertisement)
        {
            
            using (var httpclient = new HttpClient())
            {
                
                var content = new StringContent(JsonConvert.SerializeObject(advertisement), Encoding.UTF8, "application/json");
            
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Advertisement/AddAdvertisement", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var status = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    if(status.data)
                        return RedirectToAction("AdvertisementListScreenByUserId", "Advertisement");

                    return View(advertisement);

                }
               
            }
        }



        //Advertisement List Screen for Admin
        [HttpGet]

        public async Task<IActionResult> AdvertisementList()
        {
             
            ResponseModel<List<AdvertisementListVM>> responseModel = new ResponseModel<List<AdvertisementListVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Advertisement/AdvertisementListScreen"))
                {
                    flag = true;
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<AdvertisementListVM>>>(data);
                }

            }

            List<AdvertisementListVM> advertisements = responseModel.data;


            return View(advertisements);

        }


       
        //Corected code above
        [HttpGet]
        public async Task<IActionResult> AdvertisementListScreenByUserId(string userId)
        {
            string UserId = "AT10";
            //string UserId = HttpContext.Session.GetString("UserId");
            userId = UserId;

            List<AdvertisementListVM> advertisements = new List<AdvertisementListVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7208/api/Advertisement/GetAdvertisementsByUser/{userId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    advertisements = JsonConvert.DeserializeObject<List<AdvertisementListVM>>(data);
                }
            }

            return View(advertisements);
        }

        //Delete Advertisement Method 


        [HttpGet]
        [Route("DeleteAdvertisement/{advertisementId}")]
        public async Task<IActionResult> DeleteAdvertisement(int advertisementId)
        {
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.DeleteAsync($"https://localhost:7208/api/Advertisement/DeleteAdvertisement/{advertisementId}"))
                {
                

                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("AdvertisementListScreenByUserId");
                }
            }
        }

        //Edit advertisement GET method

        [HttpGet]
        [Route("EditAdvertisement/{AdvertisementId}")]

        public async Task<IActionResult> EditAdvertisement(int AdvertisementId)
        {

            Advertisement advertisement;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Advertisement/GetAdvertisementById/{AdvertisementId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    advertisement = JsonConvert.DeserializeObject<ResponseModel<Advertisement>>(data).data;

                }

                return View(advertisement);

            }

        }
        //Edit Advertisement POST method


        [HttpPost]
        [Route("EditAdvertisementPost")]
        public async Task<IActionResult> EditAdvertisementPost(Advertisement advertisement)
        {

            
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(advertisement), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PutAsync($"https://localhost:7208/api/Advertisement/EditAdvertisement", content))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("AdvertisementListScreenByUserId");

                }

            }
        }







    }
}
