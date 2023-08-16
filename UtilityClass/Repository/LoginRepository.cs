using LibraryClass.Data;
using LibraryClass.Model.Dto;
using LibraryClass.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private string secretKey;

        public LoginRepository(ApplicationDBContext applicationDBContext,IConfiguration configuration)
        {
            _applicationDBContext = applicationDBContext;
            secretKey = configuration["ApiSettings:Secret"];

        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                var response = new LoginResponse()
                {
                    Token = "",
                    User = null
                };
                return await Task.FromResult(response);
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            // Encoding of a key=> we need it in bytes and it is in string.
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loginRequest.Password),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponse loginResponse = new LoginResponse()
            {
                Token = tokenHandler.WriteToken(token),
                //User = userq
            };
            return loginResponse;
        }
    }
}
