using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace QuanLySinhVien.Localization
{
    public static class QuanLySinhVienLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(QuanLySinhVienConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(QuanLySinhVienLocalizationConfigurer).GetAssembly(),
                        "QuanLySinhVien.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
