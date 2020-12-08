using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using lightweight.core.Abstract;
using lightweight.core.Concrete;
using lightweight.data.Context;

namespace lightweight.core.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private UserRepository _userRepository;
        private DutyRepository _dutyRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public IDutyRepository Duties => _dutyRepository = _dutyRepository ?? new DutyRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
