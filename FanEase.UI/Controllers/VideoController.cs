using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models.Videos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FanEase.UI.Controllers
{
    public class VideoController : Controller
    {
        // GET: AddVideoController
        readonly IMapper _mapper;

        public VideoController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddVideoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddVideoController/Create
        [HttpGet]
        public IActionResult AddVideo()
        {
            return View();
        }

        // POST: AddVideoController/Create
        [HttpPost]
        public async Task<ActionResult> AddVideo(AddVideoVm addVideoVm)
        {
            // Video video = _mapper.Map<Video>(addVideoVm);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(addVideoVm), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Video", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                return RedirectToAction("UnderConstruction","Home");
            }
        }

        // GET: AddVideoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddVideoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: AddVideoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddVideoController/Delete/5
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
    }
}
