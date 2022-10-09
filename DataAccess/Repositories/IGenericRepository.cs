namespace DataAccess.Repositories
{
    public interface IGenericRepository<TItem> where TItem : class
    {
        Task<IQueryable<TItem>> GetAll();
        Task<TItem> GetById(object id);
        Task<bool> Insert(TItem request);
        Task<bool> Update(TItem request);
        Task<bool> Delete(object id);
        
        
    }
}
