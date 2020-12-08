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
    public class DutyRepository : Repository<Duty>, IDutyRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public DutyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Duty> GetWithUserByIdAsync(int dutyId)
        {
           return await _appDbContext.Duties.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == dutyId);
        }
    }
}
