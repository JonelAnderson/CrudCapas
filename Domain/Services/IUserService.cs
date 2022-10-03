using Domain.Common;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserService
    {
        Task<IQueryable<User>> GetAll();
        Task<User> GetById(object id);
        Task<BaseResponse<bool>> Insert(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(object id);

        Task<User> GetByName(string request);
    }
}
