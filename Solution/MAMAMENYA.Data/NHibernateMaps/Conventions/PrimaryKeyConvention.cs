using System;
using System.Linq;
using FluentNHibernate.Conventions;
using SharpArch.Core.DomainModel;

namespace MAMAMENYA.Data.NHibernateMaps.Conventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IIdentityInstance instance)
        {
            instance.Column("Id");
           
            //  instance.GeneratedBy.HiLo("1000");
            //if (instance.)
            //{
            //}
            var t = instance.EntityType;
            var idType = t.GetInterfaces().FirstOrDefault(x =>
                                               x.IsGenericType &&
                                               x.GetGenericTypeDefinition() == typeof (IHasAssignedId<>));
            if (idType!=null)
            {
                instance.GeneratedBy.Assigned();

              
                var x2 = idType.GetGenericArguments();
               
                if(x2[0]==typeof(Guid))
                {
                    
                    instance.UnsavedValue(Guid.Empty.ToString());
                }
                
            }
            else
            {
                instance.UnsavedValue("0");
                instance.GeneratedBy.Native();
            }

        }
    }
}
