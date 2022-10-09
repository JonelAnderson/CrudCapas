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
    public class TratamientoService: ITratamientoService
    {
        private readonly IGenericRepository<Tratamiento> _tratamientoRepository;
        private readonly TreatmentValidator _validationRules;

        public TratamientoService(IGenericRepository<Tratamiento> tratamientoRepository, TreatmentValidator validationRules)
        {
            _tratamientoRepository = tratamientoRepository;
            _validationRules = validationRules;
        }

        public async Task<IQueryable<Tratamiento>> GetAll()
        {
            return await _tratamientoRepository.GetAll();
        }
        public async Task<Tratamiento> GetById(object id)
        {
            return await _tratamientoRepository.GetById(id);
        }
        public async Task<BaseResponse<bool>> Insert(Tratamiento tratamiento)
        {
            //return await _tratamientoRepository.Insert(tratamiento);

            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(tratamiento);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            response.Data = await _tratamientoRepository.Insert(tratamiento);
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
        public async Task<BaseResponse<bool>> Update(Tratamiento tratamiento)
        {
            //return await _tratamientoRepository.Update(tratamiento);
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(tratamiento);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            response.Data = await _tratamientoRepository.Update(tratamiento);
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

        public async Task<bool> Delete(object id)
        {
            return await _tratamientoRepository.Delete(id);
        }

       
    }
}
