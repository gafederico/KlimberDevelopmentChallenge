using DevelopmentChallenge.Data.Classes.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes.Formas
{

    public class ReporteFormasService
    {
        private readonly IFormaLocalization _loc;
        public ReporteFormasService(IFormaLocalization loc) => _loc = loc;

        public string Print(IEnumerable<IForma> shapes)
        {
            var list = shapes?.ToList() ?? new List<IForma>();
            if (list.Count == 0)
                return _loc.EmptyList;

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(_loc.ReportTitle);

            var grouped = list.GroupBy(s => s.Clave);
            decimal totalArea = 0;
            decimal totalPerimeter = 0;
            int totalCount = 0;

            foreach (var g in grouped)
            {
                var count = g.Count();
                var area = g.Sum(x => x.Area);
                var perimeter = g.Sum(x => x.Perimetro);

                stringBuilder.Append(_loc.LineFor(g.Key, count, area, perimeter));

                totalArea += area;
                totalPerimeter += perimeter;
                totalCount += count;
            }

            stringBuilder.Append(_loc.FooterTotals(totalCount, totalArea, totalPerimeter));
            return stringBuilder.ToString();
        }
    }
}
