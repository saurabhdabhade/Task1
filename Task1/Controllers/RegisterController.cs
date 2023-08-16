using LibraryClass.Model;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models.ViewModel;
using MVCApplication.Services;
using MVCApplication.Services.IServices;
using Newtonsoft.Json;

namespace MVCApplication.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _service;
        public RegisterController(IRegisterService service)
        {
            _service = service;
        }

        public  IActionResult Create()
        {
            return View();
        }       
        public async Task<IActionResult> RegisterUser(RegisterViewModel model)
        {
            await _service.RegisterAsync<APIResponse>(model);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetAllRegisteredCustomers()
        {
            var response = await _service.GetAllAsync<APIResponse>();
            var result = JsonConvert.DeserializeObject<List<RegisterViewModel>>(Convert.ToString(response.Result));
            return View(result);
        }

        public IActionResult Edit(int RegisterID)
        {
            var response = _service.GetAsync<APIResponse>(RegisterID);
            var result = JsonConvert.DeserializeObject<RegisterViewModel>(Convert.ToString(response.Result.Result));
            return View(result);
        }
        public async Task<IActionResult> EditRegister(RegisterViewModel registerRequest)
        {
            await _service.UpdateAsync<APIResponse>(registerRequest);
            return RedirectToAction("GetAllRegisteredCustomers", "Register");
        }

        public async Task<IActionResult> Delete(int RegisterID)
        {
            await _service.DeleteAsync<APIResponse>(RegisterID);
            return RedirectToAction("GetAllRegisteredCustomers", "Register");
        }
    }
}
