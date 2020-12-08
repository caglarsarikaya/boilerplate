using lightweight.business.Abstract;
using lightweight.core.Abstract;
using lightweight.data.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace lightweight.business.Concrete
{
    public class DutyService : Service<Duty>, IDutyService
    {
        public DutyService(IUnitOfWork unitOfWork, IRepository<Duty> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Duty> GetWithUserByIdAsync(int dutyId)
        {
           return await _unitOfWork.Duties.GetWithUserByIdAsync(dutyId);
        }
    }
}
