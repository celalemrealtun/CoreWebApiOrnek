
using CoreWebApiOrnek.DAL.Concerete.EfCore.Context;
 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreWebApiOrnek.BL.Concerete.EfCore.Generic
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public EfGenericRepository(ApiContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

 
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateMatchEntity(T updateEntity, T setEntity)
        {
            if (setEntity == null)
                throw new ArgumentNullException(nameof(setEntity));

            if (updateEntity == null)
                throw new ArgumentNullException(nameof(updateEntity));

            _context.Entry(updateEntity).CurrentValues.SetValues(setEntity);//Tüm kayıtlar, kolon eşitlemesine gitmeden bir entity'den diğerine atanır.

            //Olmayan yani null gelen kolonlar, var olan tablonun üstüne ezilmesin diye ==> "IsModified = false" olarak atanır ve var olan kayıtların null olarak güncellenmesi engellenir.
            foreach (var property in _context.Entry(setEntity).Properties)
            {
                if (property.CurrentValue == null)
                {
                    _context.Entry(updateEntity).Property(property.Metadata.Name).IsModified = false;
                }
            }
            //Update(updateEntity);
        }

        
    }
}
