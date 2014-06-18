using MAMAMENYA.Core;
using FluentNHibernate.Automapping.Alterations;

namespace MAMAMENYA.Data.NHibernateMaps
{
    public class CommonCodeMap : IAutoMappingOverride<CommonCode>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<CommonCode> mapping)
        {
            mapping.Map(c => c.CommonCodeType).CustomType<CommonCodeType>();
        }
    }
}
