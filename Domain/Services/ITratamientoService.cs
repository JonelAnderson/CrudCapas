using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ITratamientoService
    {
        Task<IQueryable<Tratamiento>> GetAll();
        Task<Tratamiento> GetById(object id);
        Task<bool> Insert(Tratamiento tratamiento);
        Task<bool> Update(Tratamiento tratamiento);
        Task<bool> Delete(object id);
    }
}
