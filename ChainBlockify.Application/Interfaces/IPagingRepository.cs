using ChainBlockify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.Interfaces
{
    public interface IPagingRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetPagingListAsync(int PageNumber, int PageSize, CancellationToken cancellationToken);
    }
}
