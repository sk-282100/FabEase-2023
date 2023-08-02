using AutoMapper;

using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.State;
using FanEase.UI.Models.Videos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace FanEase.UI.Controllers
{
    public class StateController : Controller
    {
        readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public StateController(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new System.Uri("https://localhost:7208/");
        }

        [HttpGet]
        public async Task<IActionResult> AddState()
        {
            var response1 = await _httpClient.GetAsync("api/Country/Get");
            response1.EnsureSuccessStatusCode();


            var responseContent = await response1.Content.ReadAsStringAsync();


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Ensure case-insensitive property mapping
            };
            List<Country> countryList = System.Text.Json.JsonSerializer.Deserialize<ResponseModel<List<Country>>>(responseContent, options).data;

            ViewBag.CountryList = countryList;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddState(StateVm stateVm)
        {
     
            StateVm state = _mapper.Map<StateVm>(stateVm);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(state), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/State", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                
            }
            return RedirectToAction("StateList");
        }

        [HttpGet]
        public async Task<IActionResult> StateList()
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
            List<StateListVM> videolist = responseModel.data;
            return View(videolist);
        }

        [HttpGet]
        public async Task<IActionResult> StateListByStateId(int stateId)
        {
            //string UserId = "SC6656";
            //string UserId = HttpContext.Session.GetString("UserId");
            //userId = UserId;
            List<StateVm> state = new List<StateVm>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/State/{stateId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    state = JsonConvert.DeserializeObject<List<StateVm>>(data);
                }
            }

            return View(state);
        }


        [HttpGet]
        [Route("RemoveState/{StateId}")]
        public async Task<IActionResult> RemoveState(int StateId)
        {
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.DeleteAsync($"https://localhost:7208/api/State/{StateId}"))
                {

                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("StateList");
                }
            }
        }


        [HttpGet]
        [Route("EditState/{StateId}")]
        public async Task<IActionResult> EditState(int StateId)
        {
            var response1 = await _httpClient.GetAsync("api/Country/Get");
            response1.EnsureSuccessStatusCode();


            var responseContent = await response1.Content.ReadAsStringAsync();


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Ensure case-insensitive property mapping
            };
            List<Country> countryList = System.Text.Json.JsonSerializer.Deserialize<ResponseModel<List<Country>>>(responseContent, options).data;

            ViewBag.CountryList = countryList;

            State state;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/State/{StateId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    state = JsonConvert.DeserializeObject<ResponseModel<State>>(data).data;

                }
                return View(_mapper.Map<StateVm>(state));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditStatePost(StateVm state)
        {
            State state1 = _mapper.Map<State>(state);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(state1), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PutAsync($"https://localhost:7208/api/State", content))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("StateList");
                }
            }
        }


        [HttpGet]
        public async Task<IActionResult> StateDetails(int stateId)
        {
            StateVm state;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/State/{stateId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    state = JsonConvert.DeserializeObject<ResponseModel<StateVm>>(data).data;

                }
            }
            return View(state);
        }

        // GET: StateController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StateController/Edit/5
        [HttpPost]
      
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public IActionResult UnderConstruction()
        {
            return View();
        }

    }
}
