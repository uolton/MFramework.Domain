using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFramework.Domain.DomainEntity.Metadata
{
    
    public abstract class EntityMetadataBase<TEntity>:IEntityMetadata<TEntity> where TEntity:Entity<TEntity>
    {
        
        public Type IsAMedatadataOf()
        {
            return(typeof(TEntity));
        }

        public bool IsAMetadataFor(Type entityType)
        {
            return (typeof(TEntity).Equals(entityType));
        }

        public bool IsAMetadataFor<TEntityFor>() where TEntityFor:IEntity
        {
            return IsAMetadataFor(typeof(TEntityFor));
        }
        
    }
}
