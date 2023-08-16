using LibraryClass.Model.Dto;
using MVCApplication.Models.ViewModel;

namespace MVCApplication.Services.IServices
{
    public interface IRegisterService
    {
        Task<T> RegisterAsync<T>(RegisterViewModel userVM);
        Task<T> GetAllAsync<T>();
        Task<T> DeleteAsync<T>(int RegisterID);
        Task<T> UpdateAsync<T>(RegisterViewModel Entity);
        Task<T> GetAsync<T>(int RegisterID);


    }
}
