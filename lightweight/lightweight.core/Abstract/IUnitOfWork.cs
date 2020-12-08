using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lightweight.core.Abstract
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IDutyRepository Duties { get; }
        Task CommitAsync();
        void Commit();
    }
}
