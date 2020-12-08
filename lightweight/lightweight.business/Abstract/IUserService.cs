using lightweight.data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lightweight.business.Abstract
{
    public interface IUserService : IService<User>
    {
        Task<User> Authenticate(string user,string pass);

        Task<User> GetWithDutiesByIdAsync(int userId);
        Task<User> GetWithDutiesByAllAsync();

    }
}