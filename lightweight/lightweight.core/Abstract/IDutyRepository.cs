using lightweight.data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lightweight.core.Abstract
{
    public interface IDutyRepository:IRepository<Duty>
    {
        Task<Duty> GetWithUserByIdAsync(int dutyId);
    }
}
