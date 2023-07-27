using AutoMapper;

using FanEase.UI.Models;

using FanEase.UI.Models.Template;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;


namespace FanEase.UI.Controllers
{
    public class TemplateController : Controller
    {
        readonly IMapper _mapper;
        public TemplateController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AddTemplate()
        {
            return View();
        }

        [HttpGet]
        [Route("GetAllTemplatesByUser/{userId}")]
        public async Task<IActionResult> GetAllTemplatesByUser(string userId)
        {
            ResponseModel<List<TemplateListVM>> responseModel = new ResponseModel<List<TemplateListVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Template/GetAllTemplatesByUser/{userId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<TemplateListVM>>>(data);
                }

            }
            List<TemplateListVM> TemplateList = _mapper.Map<List<TemplateListVM>>(responseModel.data);
            
            return View(TemplateList);
        }


        [HttpGet]
        [Route("GetAllTemplates")]
        public async Task<IActionResult> GetAllTemplates()
        {
            ResponseModel<List<TemplateListVM>> responseModel = new ResponseModel<List<TemplateListVM>>();

            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Template/GetAllTemplates"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    responseModel = JsonConvert.DeserializeObject<ResponseModel<List<TemplateListVM>>>(data);
                }

            }
            List<TemplateListVM> TemplateList = _mapper.Map<List<TemplateListVM>>(responseModel.data);

            return View(TemplateList);
        }
    }

}
