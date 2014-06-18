using MAMAMENYA.Core;
using FluentNHibernate.Automapping.Alterations;

namespace MAMAMENYA.Data.NHibernateMaps
{
    public class UserMap:IAutoMappingOverride<User>
    {
        #region IAutoMappingOverride<User> 成员

        public void Override(FluentNHibernate.Automapping.AutoMapping<User> mapping)
        {
            //mapping.Id(c => c.Id);
            //mapping.HasManyToMany<Core.ClassRoom.Label>(c => c.Id);
            //mapping.Map(c => c.Gender).CustomType<Gender>();
            //mapping.Map(c => c.Status).CustomType<Status>();
            //mapping.Map(c => c.UserType).CustomType<UserType>();
           
        }

        #endregion
    }
}
