using IM.Web.DAL;
using IM.Web.Services;

namespace IM.Web.Helpers
{
    public static class CurrencyHelper
    {
        private static readonly ISettingService settings;

        static CurrencyHelper()
        {
            settings = new SettingService(DataContext.Current);
        }

        public static string ToCurrencyString(this decimal value)
        {
            return settings.Get<string>(SettingField.CurrencyPrefix) +
                   value.ToString("N") +
                   settings.Get<string>(SettingField.CurrencySuffix);
        }
    }
}