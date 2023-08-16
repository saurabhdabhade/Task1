using LibraryClass.Data;
using LibraryClass.Model;
using LibraryClass.Model.Dto;
using LibraryClass.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/LoginController")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {

            APIResponse _apiResponse = new APIResponse();
            var loginResponse = await _loginRepository.Login(model);
            if (loginResponse == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("Username or Password incorrect");
                return BadRequest(_apiResponse);
            }
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.IsSuccess = true;
            _apiResponse.Result = loginResponse;
            return Ok(_apiResponse);
        }
    }
}
