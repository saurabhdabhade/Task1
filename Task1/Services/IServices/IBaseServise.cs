using LibraryClass.Model;
using MVCApplication.Models;

namespace MVCApplication.Services.IServices
{
    public interface IBaseServise
    {
        APIResponse responseMode { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
