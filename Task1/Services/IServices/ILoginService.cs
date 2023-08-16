using LibraryClass.Model.Dto;
using MVCApplication.Models.ViewModel;

namespace MVCApplication.Services.IServices
{
    public interface ILoginService
    {
        Task<T> Login<T>(LoginRequest loginRequest);

        Task<RegisterViewModel> ValidateUser(string email, string password);

    }
}
