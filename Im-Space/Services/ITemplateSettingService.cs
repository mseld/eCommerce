using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IM.Web.Domain;

namespace IM.Web.Services
{
    public interface ITemplateSettingService
    {
        TemplateSetting SetSetting(string templateName, string key, string value);

        string GetSetting(string templateName, string key);
        void ResetSettings(string templateName);
    }
}
