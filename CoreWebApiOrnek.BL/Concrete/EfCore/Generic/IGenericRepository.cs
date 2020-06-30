 
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreWebApiOrnek.BL.Concerete.EfCore.Generic
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void UpdateMatchEntity(T updateEntity, T setEntity);
   
        // Task SaveAsync();
    }
}
