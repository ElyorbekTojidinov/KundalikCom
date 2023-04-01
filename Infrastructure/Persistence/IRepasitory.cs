using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    internal interface IRepasitory<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetAsync(int id);
        public Task Create(T obj);
        public Task<bool> UpdateAsync(T entity);
        public Task DeleteAsync(int id);

    }
}
