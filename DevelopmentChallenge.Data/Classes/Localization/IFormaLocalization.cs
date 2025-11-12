namespace DevelopmentChallenge.Data.Classes.Localization
{
    public interface IFormaLocalization
    {
        string ReportTitle { get; }
        string EmptyList { get; }
        string LineFor(string clave, int count, decimal area, decimal perimetro);
        string FooterTotals(int count, decimal totalArea, decimal totalPerimetro);
    }
}
