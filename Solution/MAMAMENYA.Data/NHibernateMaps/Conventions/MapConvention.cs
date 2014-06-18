using System.Linq;
using MAMAMENYA.Core;
using FluentNHibernate.Conventions;

namespace MAMAMENYA.Data.NHibernateMaps.Conventions
{
    public class PropertyConvention : IPropertyConvention
    {

        #region IConvention<IPropertyInspector,IPropertyInstance> 成员

        public void Apply(FluentNHibernate.Conventions.Instances.IPropertyInstance instance)
        {
            if (instance.Type.IsGenericType && instance.Type.GetGenericTypeDefinition().Equals(typeof(FluentNHibernate.Mapping.GenericEnumMapper<>)))
            {
               var  realType = instance.Type.GenericArguments.First();
                if (realType.IsEnum)
                {
                    instance.CustomType(realType);
                }
                
            }

            var list= instance.Property.MemberInfo.GetCustomAttributes(typeof (FieldLengthAttribute), true);
            if(list.Length>0)
            {
                instance.Length(((FieldLengthAttribute) list[0]).Length);
            }
         
        }

        #endregion
    }
}
