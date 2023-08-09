using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Advertisements;
using FanEase.UI.Models.Campaign;
using FanEase.UI.Models.Campaign.Dto;
using FanEase.UI.Models.Creator;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public async Task<ActionResult> AddCampaign(CampaignWithAdsDTO? campaignWithAdsDTO)
        {
            string userId = HttpContext.Session.GetString("UserId");
            List<AdvertisementListVM> advertisements = new List<AdvertisementListVM>();
            List<CampaignListScreenVms> Campaign;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7208/api/Advertisement/GetAdvertisementsByUser/{userId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    advertisements = JsonConvert.DeserializeObject<List<AdvertisementListVM>>(data);
                }

                using (var response = await httpClient.GetAsync($"https://localhost:7208/api/Campaign/GetAllCampaignListScreenByUserId/userId?userId={userId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Campaign = JsonConvert.DeserializeObject<ResponseModel<List<CampaignListScreenVms>>>(data).data;
                }
            }
            
            ViewBag.Advertisements = advertisements;
            ViewBag.CampaignList = Campaign;
            if(campaignWithAdsDTO==null) 
                campaignWithAdsDTO = new CampaignWithAdsDTO();
            campaignWithAdsDTO.Advertisements = new List<SelectAdvertisement>(advertisements.Count);
            //campaignWithAdsDTO.Advertisement=new AddAdvertisementVm();
            return View(campaignWithAdsDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddCampaignPost(CampaignWithAdsDTO campaignWithAdsDTO)
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

        private async Task<string> SaveAdvertisement(IFormFile advt)
        {
            var uploadPath = Path.Combine("wwwroot", "UploadAdvertisement");
            var advertisementName = Path.GetRandomFileName();
            var advertisementExtension = Path.GetExtension(advt.FileName);
            if (advertisementExtension == ".mp4" || advertisementExtension == ".jpg" || advertisementExtension == ".jpeg" || advertisementExtension == ".png")
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

        [HttpPost]
        public async Task<ActionResult> AddCampaignProceed(CampaignWithAdsDTO campaignWithAdsDTO)
        {
            string userId = HttpContext.Session.GetString("UserId");
            using (var httpclient = new HttpClient())
            {
                //if(campaignWithAdsDTO.CampaignId == 0 && campaignWithAdsDTO.Advertisement != null)
                //{

                //    if (campaignWithAdsDTO.Advertisement.UploadAdvertisement != null)
                //    {
                //        campaignWithAdsDTO.Advertisement.Image = await SaveAdvertisement(campaignWithAdsDTO.Advertisement.UploadAdvertisement);
                //        if (campaignWithAdsDTO.Advertisement.Image == null)
                //        {
                //            return RedirectToAction("AddCampaign", "Campaign", campaignWithAdsDTO);
                //        }
                //    }

                //    Advertisement add = _mapper.Map<Advertisement>(campaignWithAdsDTO.Advertisement);

                    

                //        var content = new StringContent(JsonConvert.SerializeObject(add), Encoding.UTF8, "application/json");

                //        using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Advertisement/AddAdvertisement", content))
                //        {


                //            string data = response.Content.ReadAsStringAsync().Result;
                //            var status = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);


                //        return RedirectToAction("AddCampaign", "Campaign", campaignWithAdsDTO);

                //    }

                //}
                if (campaignWithAdsDTO.CampaignId == 0)
                {
                    var content = new StringContent(JsonConvert.SerializeObject(campaignWithAdsDTO.Campaign), Encoding.UTF8, "application/json");
                    using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Campaign", content))
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                    }
                }
                
                int CampaignId = campaignWithAdsDTO.CampaignId;
                if (campaignWithAdsDTO.CampaignId == 0)
                {
                    using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Campaign/LatestAddedCampaign/{userId}"))
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        CampaignId = JsonConvert.DeserializeObject<ResponseModel<int>>(data).data;
                    }
                }
                HttpContext.Session.SetInt32("campaignId", CampaignId);
                int? VideoId = HttpContext.Session.GetInt32("videoId");

                var content1 = new StringContent(JsonConvert.SerializeObject(new AssignCampaignVM{VideoId=VideoId,CampaignId=CampaignId}), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Video/AssignCampaign", content1))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                if (campaignWithAdsDTO.CampaignId == 0)
                {
                    foreach (var ads in campaignWithAdsDTO.Advertisements)
                    {
                        if (ads.IsSelectd == true)
                        {
                            var content2 = new StringContent(JsonConvert.SerializeObject(new AssignAdvertisementVM { CampaignId = CampaignId, AdvertisementId = ads.AdvertisementId }),Encoding.UTF8, "application/json");

                            using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Campaign/AssignAdvertisement", content2))
                            {
                                string data = response.Content.ReadAsStringAsync().Result;
                            }
                        }
                    }
                }


                return RedirectToAction("AddTemplate", "Template");
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

            EditCampaign editCampaign;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Campaign/GetById?campaignId={CampaignId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    editCampaign = JsonConvert.DeserializeObject<ResponseModel<EditCampaign>>(data).data;

                }

                return View(editCampaign);

            }

        }



        [HttpPost]

        public async Task<IActionResult> EditCampaignPost(EditCampaign editCampaign)
        {


            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(editCampaign), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PutAsync($"https://localhost:7208/api/Campaign", content))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("CampaignListScreenByUserId");

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
