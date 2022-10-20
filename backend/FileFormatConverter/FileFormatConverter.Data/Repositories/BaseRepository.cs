using FileFormatConverter.Core.Interfaces.Repositories;
using FileFormatConverter.Core.Models.Common;
using FileFormatConverter.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileFormatConverter.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async virtual Task<IList<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().Select(a => a).OrderByDescending(x => x.Created).ToListAsync();
            return result;
        }

        public async virtual Task<T> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
            return result;
        }
        public async virtual Task<T> CreateAsync(T entity)
        {
            entity.Created = DateTime.Now;
            entity.Modified = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }

        public async virtual Task UpdateAsync(T entity)
        {
            entity.Modified = DateTime.Now;
            await Task.Run(() => _context.Set<T>().Update(entity));
        }

        public async virtual Task DeleteAsync(T entity)
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
        }

        public async virtual Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
