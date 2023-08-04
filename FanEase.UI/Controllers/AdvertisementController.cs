using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Advertisements;
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
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AddAdvertisement()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<ActionResult> AddAdvertisement(AddAdvertisementVm advertisement)
        {
            if (advertisement.UploadAdvertisement != null)
            {
                advertisement.Image = await SaveAdvertisement(advertisement.UploadAdvertisement);
                if (advertisement.Image == null)
                {
                    return View(advertisement);
                }
            }

            Advertisement add =  _mapper.Map<Advertisement>(advertisement);

            using (var httpclient = new HttpClient())
            {
                
                var content = new StringContent(JsonConvert.SerializeObject(add), Encoding.UTF8, "application/json");
                
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
        public async Task<ActionResult> AddAdvertisementProceed(Advertisement advertisement)
        {

        [HttpPost]
        [Route("EditAdvertisementPost")]
        public async Task<IActionResult> EditAdvertisementPost(EditAdvertisementVm advertisement)
        {
            if (advertisement.UploadAdvertisement != null)
            {
                string advtPath= await SaveAdvertisement(advertisement.UploadAdvertisement);
                if (advtPath != null)
                {
                    advertisement.Image = advtPath;
                }
                else
                {
                    ViewBag.ErrorMessage = "Only Mp4, jpeg, jpg & png files are allowed";
                    return View(advertisement);
                }
            }
            Advertisement add = _mapper.Map<Advertisement>(advertisement);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(add), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PutAsync($"https://localhost:7208/api/Advertisement/EditAdvertisement", content))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    //return RedirectToAction("AdvertisementListScreenByUserId");

                    if (HttpContext.Session.GetString("role") == "Admin")
                    {
                    return RedirectToAction("AdvertisementList");
                    }
                    else
                    {
                       return RedirectToAction("AdvertisementListScreenByUserId", new { userId = advertisement.UserId });
                    }
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


       
        //Corrected code above
        [HttpGet]
        [Route("AdvertisementListScreenByUserId")]
        public async Task<JsonResult> AdvertisementListScreenByUserId()
        {
           string UserId = HttpContext.Session.GetString("UserId");

            List<AdvertisementListVM> advertisements = new List<AdvertisementListVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7208/api/Advertisement/GetAdvertisementsByUser/{UserId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    advertisements = JsonConvert.DeserializeObject<List<AdvertisementListVM>>(data);
                }
            }

            return new JsonResult(advertisements);
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
                
                    var UserId=HttpContext.Session.GetString("UserId");
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    if (HttpContext.Session.GetString("role") == "Admin")
                    {
                       return RedirectToAction("AdvertisementList");
                    }
                    else
                    {
                       return RedirectToAction("AdvertisementListScreenByUserId", new { userId =UserId });
                    }

                   
                }
            }
        }



        [HttpGet]
        public IActionResult UnderConstruction()
        {
            return View();
        }

        //For Uploading Advertisement Video/Image
        private async Task<string> SaveAdvertisement(IFormFile advt)
        {
            var uploadPath = Path.Combine("wwwroot", "UploadAdvertisement");
            var advertisementName = Path.GetRandomFileName();
            var advertisementExtension = Path.GetExtension(advt.FileName);
            if (advertisementExtension == ".mp4"|| advertisementExtension == ".jpg"|| advertisementExtension == ".jpeg"|| advertisementExtension == ".png")
            {
                var advtPath = Path.Combine(uploadPath, advertisementName + advertisementExtension);

                using (var fileStream = new FileStream(advtPath, FileMode.Create))
                {
                    await advt.CopyToAsync(fileStream);
                }

                return (Path.Combine("UploadAdvertisement", advertisementName + advertisementExtension));
            }
            return null;
        }



    }
}
