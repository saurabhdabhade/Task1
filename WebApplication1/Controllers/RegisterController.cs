using LibraryClass.Data;
using LibraryClass.Model;
using LibraryClass.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/RegisterController")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _registerRepository;
        APIResponse _apiresponse = new APIResponse();
        public RegisterController(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        [HttpGet("{RegisterID}")]
        public async Task<ActionResult<Register>> GetRegister(int RegisterID)
        {
            try
            {
                var result = await _registerRepository.Get(RegisterID);
                if (result == null)
                {
                    return NotFound();
                }
                _apiresponse.Result = result;
                return Ok(_apiresponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Data From The Database");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetRegisterdCustomers()
        {
            try
            {
                IEnumerable<Register> blogList = await _registerRepository.GetAll();
                _apiresponse.Result = blogList;
                return Ok(_apiresponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Customer Data");
            }
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(Register registerRequest)
        {
            try
            {
                var register = await _registerRepository.Register(registerRequest);
                _apiresponse.Result = register;
                return Ok(_apiresponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retrieving Customer Data");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegister(Register register)
        {
            try
            {
                await _registerRepository.Update(register);
                _apiresponse.Result = register;
                return Ok(_apiresponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Updating with Item Record");
            }
        }

        [HttpDelete("{RegisterID}")]
        public async Task<ActionResult> DeleteRegister(int RegisterID)
        {
            try
            {
                var register = await _registerRepository.Get(RegisterID);
                if (register == null)
                {
                    return NotFound($"Item With ID = {RegisterID} Not Found");
                }
                await _registerRepository.Delete(RegisterID);
                _apiresponse.Result = $"Student With ID = {RegisterID} Is Deleted";
                return Ok(_apiresponse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Deleting with Item Record");
            }
        }
    }
}

