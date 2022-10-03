using DataAccess.Repositories;
using Domain.Common;
using Domain.Const;
using Domain.Validator;
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
        private readonly UserValidator _validationRules;

        public UserService(IGenericRepository<User> userRepository, UserValidator validationRules)
        {
            _userRepository = userRepository;
            _validationRules = validationRules;
        }

        public async Task<IQueryable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }
        public async Task<User> GetById(object id)
        {
            return await _userRepository.GetById(id);
        }
        public async Task<bool> Update(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<bool> Delete(object id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<BaseResponse<bool>> Insert(User user)
        {
            //return await _userRepository.Insert(user);
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }
            
            response.Data = await _userRepository.Insert(user);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<User> GetByName(string nameUser)
        {
            IQueryable<User> queryUserSQL = await _userRepository.GetAll();
            User? user = queryUserSQL.Where(c => c.Name == nameUser).FirstOrDefault();
            return user;
        }
       
    }
}
