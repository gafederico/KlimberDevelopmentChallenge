namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Rectangulo : IForma
    {
        private readonly decimal _ancho, _alto;
        public Rectangulo(decimal ancho, decimal alto) { _ancho = ancho; _alto = alto; }
        public string Clave => "rectangle";
        public decimal Area
        {
            get
            { return _ancho * _alto; }
        }
        public decimal Perimetro
        {
            get
            {
                return 2 * (_ancho + _alto);
            }
        }
    }
}
