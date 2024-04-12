using ChainBlockify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        public Task<T> GetByIdAsync(int Id, CancellationToken cancellationToken);
        public Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
        public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        public Task DeleteAsync(int Id, CancellationToken cancellationToken);
    }
}
