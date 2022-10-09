using Domain.Common;
using Entities.Entities;

namespace Domain.Services
{
    public interface ITratamientoService
    {
        Task<IQueryable<Tratamiento>> GetAll();
        Task<Tratamiento> GetById(object id);
        Task<BaseResponse<bool>> Insert(Tratamiento tratamiento);
        Task<BaseResponse<bool>> Update(Tratamiento tratamiento);
        Task<bool> Delete(object id);
    }
}
