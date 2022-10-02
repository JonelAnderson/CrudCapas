using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IGenericRepository<TItem> where TItem : class
    {
        Task<bool> Insert(TItem request);
        Task<bool> Update(TItem request);
        Task<bool> Delete(object id);
        Task<TItem> GetById(object id);
        Task<IQueryable<TItem>> GetAll();
    }
}
