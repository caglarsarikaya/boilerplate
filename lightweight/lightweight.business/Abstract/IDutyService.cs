using lightweight.core.Abstract;
using lightweight.data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lightweight.business.Abstract
{
    public interface IDutyService: IService<Duty>
    {
        Task<Duty> GetWithUserByIdAsync(int dutyId);
    }
}
