using MVCApplication.Models;
using MVCApplication.Models.ViewModel;
using MVCApplication.Services.IServices;

namespace MVCApplication.Services
{
    public class RegisterService : BaseService, IRegisterService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor context;
        private string registerUrl;
        private string token;
        public RegisterService(IHttpClientFactory clientFactory, IConfiguration configuration, IHttpContextAccessor context) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            this.context = context;
            registerUrl = configuration.GetValue<string>("ServiceUrls:Admin");
        }

        public Task<T> DeleteAsync<T>(int RegisterID)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Delete",
                Url = registerUrl + "RegisterController/" + RegisterID,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Get",
                Url = registerUrl + "RegisterController",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int RegisterID)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Get",
                Url = registerUrl + "RegisterController/" + RegisterID,
                Token = token
            });
        }

        public Task<T> RegisterAsync<T>(RegisterViewModel userVM)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Post",
                Data = userVM,
                Url = registerUrl + "RegisterController"
            });
        }

        public Task<T> UpdateAsync<T>(RegisterViewModel Entity)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = "Put",
                Data = Entity,
                Url = registerUrl + "RegisterController",
                Token = token
            });
        }
    }
}
