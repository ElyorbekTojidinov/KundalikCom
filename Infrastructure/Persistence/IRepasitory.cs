using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public interface IRepasitory<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<bool> AddAsync(T obj);
        public Task<bool> AddRageAsync(List<T> obj);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);

    }
}
