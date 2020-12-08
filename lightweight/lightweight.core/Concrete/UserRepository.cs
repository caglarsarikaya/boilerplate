using lightweight.core.Abstract;
using lightweight.data.Context;
using lightweight.data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lightweight.core.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task<User> GetWithDutiesByAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetWithDutiesByIdAsync(int userId)
        {
            return await _appDbContext.Users.Include(x => x.Duty).SingleOrDefaultAsync(x => x.Id == userId);
        }
    }
}
