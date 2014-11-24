using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using MFramework.Common.Assemblies.Extensions;
using MFramework.Common.Assemblies;
using MFramework.Common.Core.Collections.Extensions;
using MFramework.Common.Core.Extensions;
using MFramework.Common.Core.Types.Extensions;

namespace MFramework.Domain.DomainEntity.Metadata.Finders
{
    /// <summary>
    /// EntityMetadataFinderByClassName : Metadata
    /// </summary>
    public class EntityMetadataFinder : EntityMetadataFinderBase
    {
        
        public override bool IsMetadataFor(Type entityType,Type metadataType)
        {

            return (IsMetadata(metadataType) 
                   && (metadataType.BaseType.GenericTypeArguments.Contain(entityType)));
                  
        }

        public override bool IsMetadata(Type t)
        {
            return(t.Implement(typeof(IEntityMetadata<>)));
        }




        public override bool HasMetadata(Type t)
        {
            return ( t.Implement(typeof(Entity<>)) &&  ! AssemblyUtils.GetLoadedAssemblies().ClassThatImplement(GetSpecificMedatadataTypeFor(t)).IsEmpty());
        }
        
        
        public override Type GetMetadataClassFor(Type t)
        {
            
            IList<Type> l = AssemblyUtils.GetLoadedAssemblies().ClassThatImplement(GetSpecificMedatadataTypeFor(t));
            return(l[0]);
            Contract.EnsuresOnThrow<InvalidOperationException>(l.Count == 1, "E possibile essere definire una sola Metaclasse per entita ");
            
        }

        public override Type GetEntityOfMetadata(Type metadataType)
        {
            Contract.Requires<ArgumentException>(metadataType.Implement(typeof(IEntityMetadata<>)),"parameter metadataType  is not a Metadata");
            return (metadataType.GetGenericArguments()[0].GetType());
        }
        private Type GetSpecificMedatadataTypeFor(Type t)
        {
            return (typeof (EntityMetadataBase<>).MakeGenericType(new[] {t}));
        }
    }
}
