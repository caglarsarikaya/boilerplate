using lightweight.business.Abstract;
using lightweight.business.Middleware;
using lightweight.core.Abstract;
using lightweight.data.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace lightweight.business.Concrete
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<User> Authenticate(string user, string pass)
        {

            var response = new ServiceResponse<User>(null);
            try
            {
               
                var a = await _unitOfWork.Users.WhereAsync(x => x.Email == user && x.Password == Cipher.Encrypt("password", pass));
                var userget = a.FirstOrDefault();
                
                if (userget == null)
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("caglarcansarikaya");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, userget.Id.ToString()),
                        new Claim(ClaimTypes.Role, userget.Role)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                userget.Token = tokenHandler.WriteToken(token);

                // remove password before returning
                userget.Password = null;
          
                return userget;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        public async Task<User> GetWithDutiesByAllAsync()
        {
            return await _unitOfWork.Users.GetWithDutiesByAllAsync();
        }

        public async Task<User> GetWithDutiesByIdAsync(int userId)
        {
            return await _unitOfWork.Users.GetWithDutiesByIdAsync(userId);
        }
    }
}