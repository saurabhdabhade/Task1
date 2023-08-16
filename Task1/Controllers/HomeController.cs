using LibraryClass.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVCApplication.Models.ViewModel;
using MVCApplication.Services.IServices;
using Newtonsoft.Json;
using System.Diagnostics;
using Task1.Models;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;

        public HomeController(ILogger<HomeController> logger, ILoginService loginService, IRegisterService registerService)
        {
            _logger = logger;
            _loginService = loginService;
            _registerService = registerService;
        }

        public async Task<IActionResult> Index()
        {
            /*try
            {
                List<string> emails = new List<string>();
                var response = await _registerService.GetAllAsync<APIResponse>();
                var result = JsonConvert.DeserializeObject<List<LoginViewModel>>(Convert.ToString(response.Result));
                ViewData["registers"] = result;
                foreach (var item in result)
                {
                    emails.Add(item.Email);
                }
                ViewBag.Register = emails;
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while deserializing the JSON response.";
                errorMessage += "\nInternal Server Error: " + ex.Message;
                Console.WriteLine(errorMessage);
            }*/
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}