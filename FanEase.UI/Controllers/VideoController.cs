using AutoMapper;
using FanEase.Entity.Models;
using FanEase.UI.Models;
using FanEase.UI.Models.Creator;
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
            if (addVideoVm.UploadVideo != null)
            {
                addVideoVm.VideoFile = await SaveVideo(addVideoVm.UploadVideo);
                if (addVideoVm.VideoFile == null)
                {
                    return View(addVideoVm);
                }
            }
            addVideoVm.VideoImage = await SaveThumnail(addVideoVm.UploadVideoImage);
            if (addVideoVm.VideoImage == null)
            {
                return View(addVideoVm);
            }
            addVideoVm.VideoThumbnil = addVideoVm.VideoImage;
            AddVideoVm video = _mapper.Map<AddVideoVm>(addVideoVm);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(video), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync($"https://localhost:7208/api/Video", content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                }
                return RedirectToAction("UnderConstruction", "Home");
            }
        }


        [HttpGet]
        public async Task<IActionResult> VideoList()
        {
            ResponseModel<List<VideoListVm>> responseModel = new ResponseModel<List<VideoListVm>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Video/GetVideosList"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<VideoListVm>>>(data);
                }
            }
            List<VideoListVm> videolist = responseModel.data;
            return View(videolist);
        }


        [HttpGet]
        public async Task<IActionResult> VideoListByUSerId(string userId)
        {
          
            List<VideoListVm> videos = new List<VideoListVm>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Video/GetVideosListScreenByUserId/{userId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    videos = JsonConvert.DeserializeObject<List<VideoListVm>>(data);
                }
            }

            return View(videos);
        }


        [HttpGet]
        [Route("RemoveVideo/{VideoId}")]
        public async Task<IActionResult> RemoveVideo(int VideoId)
        {
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.DeleteAsync($"https://localhost:7208/api/Video/{VideoId}"))
                {

                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("VideoList");
                }
            }
        }




        [HttpGet]
        [Route("EditVideo/{VideoId}")]

        public async Task<IActionResult> EditVideo(int VideoId)
        {

            Video video;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Video/{VideoId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    video = JsonConvert.DeserializeObject<ResponseModel<Video>>(data).data;

                }
                return View(_mapper.Map<EditVideoVM>(video));
            }

        }

        [HttpPost]

        public async Task<IActionResult> EditVideoPost(EditVideoVM video)
        {
            if (video.UploadVideoImage != null)
            {
                string imagePath = await SaveThumnail(video.UploadVideoImage);
                if (imagePath.Contains(".jpg") || imagePath.Contains(".jpeg") || imagePath.Contains(".png"))
                {
                    video.VideoThumbnil = imagePath;
                    video.VideoImage = imagePath;
                }

                else
                {
                    ViewBag.ErrorMessage = " only files with .jpg, .jpeg & .png are allowed";
                    return View(video);
                }

            }
            if (video.UploadVideo != null)
            {
                string videoPath = await SaveVideo(video.UploadVideo);
                if (videoPath != null)
                {
                    video.VideoFile = videoPath;
                }

                else
                {
                    ViewBag.ErrorMessage = " only mp4 videos allowed";
                    return View(video);
                }

            }
            Video video1 = _mapper.Map<Video>(video);
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(video1), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PutAsync($"https://localhost:7208/api/Video/EditVideo", content))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("VideoList");

                }

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

        private async Task<string> SaveThumnail(IFormFile image)
        {
            var uploadPath = Path.Combine("wwwroot", "UploadImage", "VideoThumnail");
            var imageName = Path.GetRandomFileName();
            var imageExtension = Path.GetExtension(image.FileName);
            if (imageExtension == ".png" || imageExtension == ".jpg" || imageExtension == ".jpeg")
            {
                var imagePath = Path.Combine(uploadPath, imageName + imageExtension);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                return (Path.Combine("UploadImage", "VideoThumnail", imageName + imageExtension));
            }
            return null;
        }

        private async Task<string> SaveVideo(IFormFile video)
        {
            var uploadPath = Path.Combine("wwwroot", "Videos");
            var videoName = Path.GetRandomFileName();
            var videoExtension = Path.GetExtension(video.FileName);
            if (videoExtension == ".mp4")
            {
                var videoPath = Path.Combine(uploadPath, videoName + videoExtension);

                using (var fileStream = new FileStream(videoPath, FileMode.Create))
                {
                    await video.CopyToAsync(fileStream);
                }

                return (Path.Combine("Videos", videoName + videoExtension));
            }
            return null;
        }

    }
}
