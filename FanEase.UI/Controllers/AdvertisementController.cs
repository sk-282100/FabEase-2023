﻿using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Creator;
using FanEase.UI.Models.Videos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
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
           // string UserId = "AT10";
            
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
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<AdvertisementListVM>>>(data);
                }

            }

            List<AdvertisementListVM> advertisements = new List<AdvertisementListVM>();
            
            return View(advertisements);

        }


        //Advertisement ListScreen for a perticular User


        //[HttpGet]

        //public async Task<IActionResult> AdvertisementListScreenByUserId(string userId)
        //{
        //    string UserId = "AT10";
        //    //string UserId = HttpContext.Session.GetString("UserId");
        //    userId = UserId;
        //    ResponseModel<List<AdvertisementListVM>> responseModel = new ResponseModel<List<AdvertisementListVM>>();

        //    using (var httpclient = new HttpClient())
        //    {
             
                
        //        using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Advertisement/GetAdvertisementsByUser/{userId}"))
        //        {
        //            string data = await response.Content.ReadAsStringAsync();
        //            responseModel = JsonConvert.DeserializeObject<ResponseModel<List<AdvertisementListVM>>>(data);
        //        }

        //    }
        //    List<AdvertisementListVM> advertisements = new List<AdvertisementListVM>();

        //    return View(advertisements);

        //}

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




    }
}