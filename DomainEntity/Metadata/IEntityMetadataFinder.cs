using System;

namespace MFramework.Domain.DomainEntity.Metadata
{
    /// <summary>
    /// IEntityMetadataFinder : restituisce la classe che rappresenta i metadati di una classe
    /// </summary>
    public interface  IEntityMetadataFinder
    {
        /// <summary>
        /// GetMetadataClassFor Restituisce la classe che rappresenta i metadati di una classe
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        Type GetMetadataClassFor<TEntity>() where TEntity : Entity<TEntity>;
        Type GetMetadataClassFor(Type t);
        
        /// <summary>
        /// IsMetadataFor verifica se una determinata classe e un metadato di una'altro
        /// </summary>
        /// <typeparam name="TMetadata"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        bool IsMetadataFor<TMetadata, TEntity>()
            where TEntity : Entity<TEntity>
            where TMetadata : IEntityMetadata<TEntity>;
        bool IsMetadataFor<TEntity>(Type metadataType) where TEntity : Entity<TEntity>;
        bool IsMetadataFor(Type entityType,Type metadataType) ;

        bool HasMetadata<TEntity>() where TEntity :Entity<TEntity>;
        bool HasMetadata(Type T);
        Type GetEntityOfMetadata<T>() where T:IEntityMetadata<IEntity>;
        Type GetEntityOfMetadata(Type metadataType);
        /// <summary>
        /// IsMetadata verifica se una classe è una classe Metadata
        /// </summary>
        /// <typeparam name="TMetadata"></typeparam>
        /// <returns></returns>
        bool IsMetadata<TMetadata>();
        bool IsMetadata(Type t);
    }
}
