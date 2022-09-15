﻿using DataAccess.Repositories;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IQueryable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }
        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }
        public async Task<bool> Update(User request)
        {
            return await _userRepository.Update(request);
        }

        public async Task<bool> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<bool> Insert(User request)
        {
            return await _userRepository.Insert(request);
        }

        public async Task<User> GetByName(string nameUser)
        {
            IQueryable<User> queryUserSQL = await _userRepository.GetAll();
            User user = queryUserSQL.Where(c => c.Name == nameUser).FirstOrDefault();
            return user;
        }

        

       
    }
}
