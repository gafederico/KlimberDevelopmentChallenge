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

            var sb = new StringBuilder();
            sb.Append(_loc.ReportTitle);

            var grouped = list.GroupBy(s => s.Clave);
            decimal totalArea = 0;
            decimal totalPerimeter = 0;
            int totalCount = 0;

            foreach (var g in grouped)
            {
                int count = g.Count();
                decimal area = g.Sum(x => x.Area);
                decimal per = g.Sum(x => x.Perimetro);

                sb.Append(_loc.LineFor(g.Key, count, area, per));

                totalArea += area; totalPerimeter += per; totalCount += count;
            }

            sb.Append(_loc.FooterTotals(totalCount, totalArea, totalPerimeter));
            return sb.ToString();
        }
    }
}
