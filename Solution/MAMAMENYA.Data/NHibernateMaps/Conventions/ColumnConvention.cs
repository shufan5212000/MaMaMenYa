using FluentNHibernate.Conventions;

namespace MAMAMENYA.Data.NHibernateMaps.Conventions
{
    public class ColumnConvention : IColumnConvention
    {
        #region IConvention<IColumnInspector,IColumnInstance> 成员

        public void Apply(FluentNHibernate.Conventions.Instances.IColumnInstance instance)
        {
            var type = instance.EntityType;

        }

        #endregion
    }
}
