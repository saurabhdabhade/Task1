using LibraryClass.Data;
using LibraryClass.Model;
using LibraryClass.Model.Dto;
using Microsoft.EntityFrameworkCore;
using MVCApplication.Models;
using MVCApplication.Models.ViewModel;
using MVCApplication.Services.IServices;

namespace MVCApplication.Services
{
    public class LoginService : BaseService ,ILoginService
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor context;
        private string loginUrl;
        private string token;

        public LoginService(IHttpClientFactory clientFactory, IConfiguration configuration, IHttpContextAccessor context, ApplicationDBContext applicationDBContext) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            _applicationDBContext = applicationDBContext;
            loginUrl = configuration.GetValue<string>("ServiceUrls:Admin");
        }
        public Task<T> Login<T>(LoginRequest loginRequest)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Post",
                Data = loginRequest,
                Url = loginUrl + "LoginController/login"
            });
        }

        public async Task<RegisterViewModel> ValidateUser(string email, string password)
        {
            var user = await _applicationDBContext.registers
             .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                return null; // User not found
            }
            // Perform the conversion from LibraryClass.Model.Register to MVCApplication.Models.ViewModel.RegisterViewModel
            var viewModelUser = ConvertToViewModel(user);

            return viewModelUser;
        }

        private RegisterViewModel ConvertToViewModel(Register user)
        {
            var viewModelUser = new RegisterViewModel
            {
                // Map properties accordingly
                RegisterID = user.RegisterID,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                Password = user.Password,
                Confirm_Password = user.Confirm_Password,
            };

            return viewModelUser;
        }
    }
}
