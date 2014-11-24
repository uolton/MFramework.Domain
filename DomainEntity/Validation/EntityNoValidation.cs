namespace MFramework.Domain.DomainEntity.Validation
{
    /// <summary>
    /// Class EntityNoValidation<TEntity, TId>
    /// Classe di validazione di un entita : E  la  classe sepcifica per le entita che non necessitano di alcuna 
    /// validazione 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    class EntityNoValidation<TEntity>:EntityValidatorBase<TEntity>  where TEntity:Entity<TEntity>
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public EntityNoValidation() { }
        #endregion
        

    }
}
