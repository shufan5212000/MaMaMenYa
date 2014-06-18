using MAMAMENYA.Core;
using FluentNHibernate.Automapping.Alterations;

namespace MAMAMENYA.Data.NHibernateMaps
{
    public class SettingMap : IAutoMappingOverride<Setting>
    {
        #region IAutoMappingOverride<Setting> 成员

        public void Override(FluentNHibernate.Automapping.AutoMapping<Setting> mapping)
        {
            mapping.Id(c => c.Id).GeneratedBy.Assigned();
        }

        #endregion
    }
}
