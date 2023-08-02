using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models.State;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text;
using FanEase.UI.Models;
using FanEase.UI.Models.City;

namespace FanEase.UI.Controllers
{
    public class CityController : Controller
    {
        readonly IMapper _mapper;
        

        public CityController(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AddCity()
        {
            ResponseModel<List<StateListVM>> responseModel = new ResponseModel<List<StateListVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/State"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<StateListVM>>>(data);
                }
            }
            List<StateListVM> statelist = responseModel.data;
            ViewBag.StateList = statelist;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddCity(CityVm cityVm)
        {

            CityVm city = _mapper.Map<CityVm>(cityVm);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/City", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }

            }
            return RedirectToAction("CityList");
        }

        [HttpGet]
        public async Task<IActionResult> CityList()
        {
            ResponseModel<List<CityListVM>> responseModel = new ResponseModel<List<CityListVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/City"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<CityListVM>>>(data);
                }
            }
            List<CityListVM> videolist = responseModel.data;
            return View(videolist);
        }

        [HttpGet]
        public async Task<IActionResult> CityListByStateId(int cityId)
        { 
            List<CityVm> city = new List<CityVm>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/City/{cityId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    city = JsonConvert.DeserializeObject<List<CityVm>>(data);
                }
            }

            return View(city);
        }


        [HttpGet]
        [Route("RemoveCity/{CityId}")]
        public async Task<IActionResult> RemoveCity(int CityId)
        {
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.DeleteAsync($"https://localhost:7208/api/City/{CityId}"))
                {

                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("CityList");
                }
            }
        }


        [HttpGet]
        [Route("EditCity/{CityId}")]
        public async Task<IActionResult> EditCity(int CityId)
        {
            ResponseModel<List<StateListVM>> responseModel = new ResponseModel<List<StateListVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/State"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<StateListVM>>>(data);
                }
            }
            List<StateListVM> statelist = responseModel.data;
            ViewBag.StateList = statelist;

            City city;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/City/{CityId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    city = JsonConvert.DeserializeObject<ResponseModel<City>>(data).data;

                }
                return View(_mapper.Map<CityVm>(city));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditCityPost(CityVm city)
        {
            City city1 = _mapper.Map<City>(city);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(city1), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PutAsync($"https://localhost:7208/api/City", content))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("CityList");
                }
            }
        }


        [HttpGet]
        public async Task<IActionResult> CityDetails(int cityId)
        {
            CityVm city;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/City/{cityId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    city = JsonConvert.DeserializeObject<ResponseModel<CityVm>>(data).data;

                }
            }
            return View(city);
        }

        [HttpGet]
        public IActionResult UnderConstruction()
        {
            return View();
        }
    }
}
