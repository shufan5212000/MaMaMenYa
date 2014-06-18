using FluentNHibernate.Conventions;

namespace MAMAMENYA.Data.NHibernateMaps.Conventions
{
    public class TableNameConvention : IClassConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IClassInstance instance)
        {

            string name = instance.EntityType.FullName.Replace("MAMAMENYA.Core.", "").Replace(".", "_");
            instance.Table(Inflector.Net.Inflector.Pluralize(name));
        }
    }
}
