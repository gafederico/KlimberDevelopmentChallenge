using System.Globalization;

namespace DevelopmentChallenge.Data.Classes.Localization
{
    public static class FormaLocalizationFactory
    {
        public static IFormaLocalization From(int idioma)
        {
            LocalizationResx localization;
            switch (idioma)
            {
                case FormaGeometrica.Castellano:
                    localization = new LocalizationResx("es");
                    break;
                case FormaGeometrica.Ingles:
                    localization = new LocalizationResx("en");
                    break;
                case FormaGeometrica.Italiano:
                    localization = new LocalizationResx("it");
                    break;
                default:
                    localization = new LocalizationResx(CultureInfo.InvariantCulture.TwoLetterISOLanguageName);
                    break;
            }
            return localization;
        }
    }
}
