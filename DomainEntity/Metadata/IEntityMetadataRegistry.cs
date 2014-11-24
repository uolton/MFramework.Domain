namespace MFramework.Domain.DomainEntity.Metadata
{
   /// <summary>
    /// IEntityMetadataRegistry Interfaccia generica delle classi che implementano la politica
    /// di registrazione dei metadati della classe con il servizio di validazione delle entita 
   /// </summary>
    public interface IEntityMetadataRegistry
    {
        /// <summary>
        /// RegisterMetadataFor registra la classe dei metadatai associata alla classe 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        void RegisterMetadataFor<TEntity>() where TEntity:Entity<TEntity>;
    }
}
