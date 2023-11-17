using CDN_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DapperData.Models;

namespace CDN_UI.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7285/api");
        private readonly HttpClient _httpClient;
        public UserController()
        {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = baseAddress;
        }
        /// <summary>
        /// Get user list from api
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            IEnumerable<UserViewModel> users2 = new List<UserViewModel>();  
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/User/Get").Result;
            if (response.IsSuccessStatusCode) 
            { 
                string data = response.Content.ReadAsStringAsync().Result;
                users2 = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }
            return View(users2);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(string code)
        {
            ViewData["editcode"] = code;
            return View();
        }        
    }    
}
