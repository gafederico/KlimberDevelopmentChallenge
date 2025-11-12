namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Cuadrado : IForma
    {
        private readonly decimal _lado;
        public Cuadrado(decimal lado) { _lado = lado; }
        public string Clave => "square";
        public decimal Area
        {
            get { return _lado * _lado; }
        }
        public decimal Perimetro
        {
            get { return 4 * _lado; }
        }
    }
}