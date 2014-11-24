using System;

namespace MFramework.Domain.DomainEntity.Metadata
{
    /// <summary>
    /// EntityMetadataFinderBase : implementazione base di un MetadataFinder
    /// </summary>
    public abstract class EntityMetadataFinderBase : IEntityMetadataFinder
    {
        protected EntityMetadataFinderBase(){}

        public abstract bool IsMetadataFor(Type entityType, Type metadataType);
        public abstract bool IsMetadata(Type t);
        public abstract Type GetMetadataClassFor(Type t);

        public Type GetEntityOfMetadata<T>() where T:IEntityMetadata<IEntity>
        {
            return (GetEntityOfMetadata(typeof (T)));
        }

        public abstract Type GetEntityOfMetadata(Type metadataType);

        public bool HasMetadata<TEntity>() where TEntity :Entity<TEntity>
        {
            return HasMetadata(typeof(TEntity));
        }

        public abstract bool HasMetadata(Type T);
        public Type GetMetadataClassFor<TEntity>() where TEntity : Entity<TEntity>
        {
            return GetMetadataClassFor(typeof (TEntity));
        }
        public bool IsMetadataFor<TMetadata, TEntity>() 
            where TEntity : Entity<TEntity> 
            where  TMetadata:IEntityMetadata<TEntity> 
        {
            return IsMetadataFor<TEntity>(typeof(TMetadata));
        }

        public bool IsMetadataFor<TEntity>(Type metadataType) where TEntity : Entity<TEntity>
        {
            return IsMetadataFor(typeof (TEntity), metadataType);
        }

        public bool IsMetadata<TMetadata>()
        {
            return IsMetadata(typeof(TMetadata));
        }

    }
}
