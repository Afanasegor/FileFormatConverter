using FileFormatConverter.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileFormatConverter.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task SaveAsync();
    }
}
