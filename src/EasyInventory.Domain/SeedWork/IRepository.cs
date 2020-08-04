namespace EasyInventory.Domain.SeedWork
{
    /// <summary>
    /// Class or component that encapsulate the logic required to access data sources
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}