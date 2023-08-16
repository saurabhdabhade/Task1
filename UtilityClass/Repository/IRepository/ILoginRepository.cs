using LibraryClass.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass.Repository.IRepository
{
    public interface ILoginRepository
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
