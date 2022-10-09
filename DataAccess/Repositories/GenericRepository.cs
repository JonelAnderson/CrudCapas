using DataAccess.DBContetx;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<TItem> : IGenericRepository<TItem> where TItem : class
    {
        private readonly ApplicationDbContext _dbcontext;

        public GenericRepository(ApplicationDbContext context)
        {
            _dbcontext = context;
        }
        public Task<IQueryable<TItem>> GetAll()
        {
            try
            {
                IQueryable<TItem> entity = _dbcontext.Set<TItem>();

                return Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                throw new DataException("Failed to get data.", ex);
            }

        }

        public async Task<bool> Insert(TItem entity)
        {

            try
            {
                _dbcontext.Add(entity);
                await _dbcontext.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                throw new DataException("Failed to insert data.", ex);
            }
        }

        public async Task<bool> Update(TItem entity)
        {


            try
            {
                _dbcontext.Update(entity);
                await _dbcontext.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                throw new DataException("Failed to update data.", ex);
            }
        }
        public async Task<bool> Delete(object id)
        {

            try
            {
                TItem? request = await _dbcontext.Set<TItem>().FindAsync(id);
                 _ = _dbcontext.Remove(request!);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new DataException("Failed to delete data.", ex);
            }


        }


        public async Task<TItem> GetById(object id)
        {
            try
            {
                return await _dbcontext.Set<TItem>().FindAsync(id);

            }
            catch (Exception ex)
            {

                throw new DataException("Failed to get data for id.", ex);
            }
        }


    }
}
