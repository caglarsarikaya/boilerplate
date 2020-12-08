using lightweight.data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lightweight.core.Abstract
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetWithDutiesByIdAsync(int userId);
        Task<User> GetWithDutiesByAllAsync();
    }
}
