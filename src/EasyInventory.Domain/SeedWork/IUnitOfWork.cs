using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyInventory.Domain.SeedWork
{
    /// <summary>
    /// Maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}