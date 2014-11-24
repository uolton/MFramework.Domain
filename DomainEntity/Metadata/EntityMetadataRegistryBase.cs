using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using MFramework.Common.CustomTypeProviders.Configurers;
using MFramework.Common.CustomTypeProviders.Providers;

namespace MFramework.Domain.DomainEntity.Metadata
{
    /// <summary>
    /// Classe per l'implementazione base delle policy
    /// </summary>
    public abstract class EntityMetadataRegistryBase<TFinder> : IEntityMetadataRegistry where TFinder : class,IEntityMetadataFinder, new()
    {
        [NotNull] protected TFinder _finder;
        #region Constructor
        protected EntityMetadataRegistryBase():this(new TFinder())
        {
        }
        protected EntityMetadataRegistryBase(TFinder finder )
        {
            _finder = finder;
        }
        #endregion
        
        /// <summary>
        /// GetMetadataClass Restituisce il tipo che rappresenta la metaclasse del tipo specificato 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        /// 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected Type GetMetadataClass(Type t)
        {
            return(_finder.GetMetadataClassFor(t));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected Type GetMetadataClass<TEntity>() where TEntity : Entity<TEntity>
        {
            return GetMetadataClass(typeof (TEntity));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected bool HaveMetaClass(Type entityType)
        {
            return (_finder.HasMetadata(entityType));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected bool HaveMetaClass<TEntity>() where TEntity : Entity<TEntity>
        {
            return (_finder.HasMetadata<TEntity>());
        }

        private void RegisterMetadataRegisterProvider(Type entityType,Type metadataEntityType)
        {
            var descriptionProvider = new AssociatedMetadataTypeTypeDescriptionProvider(entityType, metadataEntityType);

            TypeDescriptor.AddProviderTransparent(descriptionProvider, entityType);
        }
        private void RegisterMetadataRegisterMetadataAttribute<TEntity>(Type metadataEntityType) where TEntity : Entity<TEntity>
        {
            CustomTypeDescriptorProvider<TEntity>.Register<DefaultCustomTypeDescriptorConfiguratorBuilder>().Configure(
                modifier =>
                {
                    if (! modifier.TypeAttibutes.Any(a => a is MetadataTypeAttribute))
                        modifier.AddTypeAttribute(new MetadataTypeAttribute(metadataEntityType));
                    return true;
                });
        }
        /// <summary>
        /// RegisterMetadataFor<TEntity> registrazione della classe contenente i metadati
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        public  void RegisterMetadataFor<TEntity>() where TEntity : Entity<TEntity>
        {

            if (!HaveMetaClass<TEntity>()) return;

            RegisterMetadataRegisterProvider(typeof (TEntity), GetMetadataClass<TEntity>());
            RegisterMetadataRegisterMetadataAttribute<TEntity>(GetMetadataClass<TEntity>());
            //var descriptionProvider =new AssociatedMetadataTypeTypeDescriptionProvider(typeof(TEntity),GetMetadataClass<TEntity>());
            
            //TypeDescriptor.AddProviderTransparent(descriptionProvider, typeof(TEntity));
            
            
        }

        /// <summary>
        /// Custom attribute provider per "inject" dell'attributo MetadataClass
        /// </summary>
        private class MetadataAttributeCustomDescriptor : TypeDescriptionProvider
        {
            
        }
    }
}
