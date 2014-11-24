using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Resources;
using MFramework.Common.Actions;
using MFramework.Domain.DomainEntity.Metadata;

namespace MFramework.Domain
{
    /// <summary>
    /// EntityWithMetadata:Classe base delle entita del dominio che presentano una Metadata legata alla classe, 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityWithMetadata<TEntity>:Entity<TEntity> where TEntity : Entity<TEntity>
    {
        // Attivo la registrazione della classe Metadata della classe Entity 
        // La registrazione avverra un unica volta per singola classe
        private DoItOnceAction<DoItOnceActionClassContext<TEntity>> _metaDataDoReg =
            new DoItOnceAction<DoItOnceActionClassContext<TEntity>>(RegisterMetaData);
        private static EntityMetadataRegistry _metadataRegistry = new EntityMetadataRegistry();

        /// <summary>
        /// Registrazione della MetaData Class associata all'Entita <TEntity>
        /// </summary>

        private static void RegisterMetaData()
        {
            _metadataRegistry.RegisterMetadataFor<TEntity>();

        }
    }
}
