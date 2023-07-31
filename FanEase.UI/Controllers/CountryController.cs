using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FanEase.UI.Models.Country;
using AutoMapper;
using Microsoft.Extensions.Options;
using System.Text.Json;
using FanEase.Entity.Models;
using Newtonsoft.Json;
using System.Text.Json;
using FanEase.UI.Models;
using Country = FanEase.UI.Models.Country.Country;
using System.Diagnostics.Metrics;
using System.Text;
using NuGet.Protocol.Core.Types;

namespace FanEase.UI.Controllers
{
    public class CountryController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public CountryController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new System.Uri("https://localhost:7208/"); // Replace with the base URL of your API
            _mapper = mapper;
        }

        public async Task<IActionResult> AddCountry()
        {
            List<Country> CountryList =  await GetCountryListAsync();

            ViewBag.Country = CountryList;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync("api/Country", country); // Assuming "Country" is the API endpoint for adding a country
                    response.EnsureSuccessStatusCode();

                    // Fetch the updated country list after successful addition
                    var updatedCountryList = await GetCountryListAsync();
                   

                    // Pass the updated country list and the newly added country to the view
                    ViewBag.Country = updatedCountryList;
                    ViewBag.RecentlyAddedCountry = country;

                    return View();
                }
                catch (HttpRequestException)
                {
                    // Handle API error
                    ModelState.AddModelError("", "Failed to add country.");
                }
            }

            // If the model is not valid, redisplay the AddCountry view with validation errors
            return View(new Countryvm());
        }

        // Method to get the list of countries from the API
        private async Task<List<Country>> GetCountryListAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Country/Get");
                response.EnsureSuccessStatusCode();
            

                var responseContent = await response.Content.ReadAsStringAsync();

                
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Ensure case-insensitive property mapping
                };
                var countryList = System.Text.Json.JsonSerializer.Deserialize<ResponseModel<List<Country>>>(responseContent, options).data;

                return countryList;
            }
            catch (HttpRequestException)
            {
                // Handle API error
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCountry(string CountryId)
        {
            try
            {
                using (var response = await _httpClient.DeleteAsync($"api/Country?countryId={CountryId}"))
                {
                    response.EnsureSuccessStatusCode();

                    // Fetch the updated country list after successful deletion
                    var updatedCountryList = await GetCountryListAsync();

                    // Pass the updated country list and the recently deleted country ID to the view
                    ViewBag.Country = updatedCountryList;
                    ViewBag.RecentlyDeletedCountry = CountryId;
                }
            }
            catch (HttpRequestException)
            {
                // Handle API error
                ModelState.AddModelError("", "Failed to remove country.");
            }

            // Redirect to the AddCountry action to display the result
            return RedirectToAction("AddCountry");
        }

        [HttpGet]
        

        public async Task<IActionResult> EditCountry(int CountryId)
        {

            Country country;
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"https://localhost:7208/api/Country/GetById?countryId={CountryId}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    country = JsonConvert.DeserializeObject<ResponseModel<Country>>(data).data;

                }

                return View(country);

            }

        }



        [HttpPost]
        

        public async Task<IActionResult> EditCountry(Country country) // Rename the parameter to lowercase countryId
        {

            
            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json");
                using (var response = await httpclient.PutAsync($"https://localhost:7208/api/Country", content))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResponseModel<bool>>(data);

                    return RedirectToAction("AddCountry");

                }

            }
            
        }
        

    }
}
