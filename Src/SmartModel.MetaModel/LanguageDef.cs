namespace SmartModel
{
    public class LanguageDef
    {
        public static LanguageDef ChineseLang(string name)
        {
            return new LanguageDef
            {
                CultureName = "zh",
                Name = name
            };
        }
        public static LanguageDef EnglishLang(string name)
        {
            return new LanguageDef
            {
                CultureName = "en",
                Name = name
            };
        }

        public string Name { get; set; } = "";
        public string CultureName { get; set; } = "";
    }
}