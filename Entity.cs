using MFramework.Domain.DomainEntity;
using MFramework.Domain.DomainEntity.Validation;
using MFramework.Domain.Validation;
namespace MFramework.Domain
{
    /// <summary>
    ///     Интерфейс сущности доменной модели
    /// </summary>
    public abstract class Entity<TEntity> : EntityWithTypedId<int, TEntity> where TEntity : Entity<TEntity>
    {
        #region Constructors
            protected Entity() : base(new EntityNoValidation<TEntity>()) { }
            protected Entity(IValidator<TEntity> validator) : base(validator) { }
            
        #endregion
    }
}