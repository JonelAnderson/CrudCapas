using DataAccess.Repositories;
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

        public TratamientoService(IGenericRepository<Tratamiento> tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        public async Task<IQueryable<Tratamiento>> GetAll()
        {
            return await _tratamientoRepository.GetAll();
        }
        public async Task<Tratamiento> GetById(object id)
        {
            return await _tratamientoRepository.GetById(id);
        }
        public async Task<bool> Insert(Tratamiento tratamiento)
        {
            return await _tratamientoRepository.Insert(tratamiento);
        }
        public async Task<bool> Update(Tratamiento tratamiento)
        {
            return await _tratamientoRepository.Update(tratamiento);
        }

        public async Task<bool> Delete(object id)
        {
            return await _tratamientoRepository.Delete(id);
        }

       
    }
}
