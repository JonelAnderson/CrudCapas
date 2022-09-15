using DataAccess.DBContetx;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        private readonly ApplicationDbContext _dbcontext;

        public UserRepository(ApplicationDbContext context)
        {
            _dbcontext = context;
        }
        public async Task<IQueryable<User>> GetAll()
        {
            IQueryable<User> users = _dbcontext.Users;
            return users;
        }
        public async Task<User> GetById(int id)
        {
            return await _dbcontext.Users.FindAsync(id);
        }
        public async Task<bool> Update(User request)
        {
            _dbcontext.Users.Update(request);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Delete(int id)
        {
            User request= _dbcontext.Users.First(c => c.Id == id);
            _dbcontext.Users.Remove(request);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insert(User request)
        {
            _dbcontext.Users.Add(request);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    

        
    }
}
