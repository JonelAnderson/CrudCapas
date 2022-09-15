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
        Task<User> GetById(int id);
        Task<bool> Insert(User request);
        Task<bool> Update(User request);
        Task<bool> Delete(int id);

        Task<User> GetByName(string nameUser);
    }
}
