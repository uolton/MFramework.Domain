namespace MFramework.Domain.DomainEntity
{
    /// <summary>
    ///     This serves as a base interface for <see cref="EntityWithTypedId{TId}" /> and 
    ///     <see cref = "GbDoc.Infrastructure.Domain.Entity" />. Also provides a simple means to develop your own base entity.
    /// </summary>
    public interface IEntityWithTypedId<TId>:IEntity
    {
        TId Id { get; }
    }
}