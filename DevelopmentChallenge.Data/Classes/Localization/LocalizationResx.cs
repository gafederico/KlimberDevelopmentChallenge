using System.Globalization;
using System.Resources;
using DevelopmentChallenge.Data.Classes.Localization.Resources;

namespace DevelopmentChallenge.Data.Classes.Localization
{
    public class LocalizationResx : IFormaLocalization
    {
        private readonly ResourceManager _rm = Report.ResourceManager;
        private readonly CultureInfo _culture;

        public LocalizationResx(string cultureName)
        {
            _culture = new CultureInfo(cultureName);
        }

        public string ReportTitle
        {
            get
            {
                return _rm.GetString("Header", _culture);
            }
        }
        public string EmptyList
        {
            get
            {
                return _rm.GetString("Empty", _culture);
            }
        }

        public string LineFor(string key, int count, decimal area, decimal perimeter)
        {
            var shapeName = _rm.GetString($"shape.{key}.{(count == 1 ? "singular" : "plural")}", _culture) ?? key;
            var formatString = _rm.GetString("Line", _culture);

            // Los tests siempre esperan "," como delimitador, indiferentemente del idioma. Por eso este hack.
            var numberCulture = (CultureInfo)_culture.Clone();
            numberCulture.NumberFormat.NumberDecimalSeparator = ",";
            numberCulture.NumberFormat.NumberGroupSeparator = ".";

            var areaStr = area.ToString("#.##", numberCulture);
            var perStr = perimeter.ToString("#.##", numberCulture);

            return string.Format(_culture, formatString, count, shapeName, areaStr, perStr);
        }

        public string FooterTotals(int count, decimal totalArea, decimal totalPerimeter)
        {
            var formatString = _rm.GetString("Total", _culture);

            // Los tests siempre esperan "," como delimitador, indiferentemente del idioma. Por eso este hack.
            var numberCulture = (CultureInfo)_culture.Clone();
            numberCulture.NumberFormat.NumberDecimalSeparator = ",";
            numberCulture.NumberFormat.NumberGroupSeparator = ".";

            var perimeterString = totalPerimeter.ToString("#.##", numberCulture);
            var areaString = totalArea.ToString("#.##", numberCulture);

            return string.Format(_culture, formatString, count, perimeterString, areaString);
        }
    }
}
