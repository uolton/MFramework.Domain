using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFramework.Domain.DomainEntity
{
    /// <summary>
    /// IEntityMetadata<TEntity> :Interfaccia che identifica un Metadata di un entita
    /// Metadata fornisce informazioni aggiuntive relative all'entita in oggetto 
    /// <TEntita>  Entita
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntityMetadata<TEntity>  where TEntity:IEntity
    {
        /// <summary>
        /// IsAMedatadataOf Restituisce il tipo di entita di cui è Metadata
        /// </summary>
        /// <returns>Type : Tipo dell'entita</returns>
        Type IsAMedatadataOf();
        
        /// <summary>
        /// IsAMetadata : verifica se è l'entità  di cui costituisce il metadata
        /// </summary>
        /// <param name="EntityType"></param>
        /// <returns></returns>
        bool IsAMetadataFor(Type EntityType);
        bool IsAMetadataFor<TEntityFor>() where TEntityFor:IEntity;
        

    }
}
