using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IM.Web.Services
{
    public interface ISettingService
    {
        T Get<T>(SettingField key);
        void Set<T>(SettingField key, T value);
    }
}