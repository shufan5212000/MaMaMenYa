using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public interface ISettingRepository : IRepositoryWithTypedId<Setting, string>
    {
        T Get<T>() where T : new();

        void Save<T>(T setting) where T : new();
        void Delete<T>();
    }
}
