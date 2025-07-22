using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseSwRepository<T> : ISwRepository<T> where T : class
    {

        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseSwRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dataset.FindAsync(id);
            if (entity == null) return false;

            _dataset.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistAsync(int id)
        {
            var entity = await _dataset.FindAsync(id);
            return entity != null;
        }

        public async Task<T> FindByConditionAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dataset.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> InsertAsync(T item)
        {
            await _dataset.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> SelectAsync(int id)
        {
            return await _dataset.FindAsync(id);
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            _dataset.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}