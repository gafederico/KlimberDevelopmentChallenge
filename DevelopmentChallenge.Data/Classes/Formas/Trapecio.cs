namespace DevelopmentChallenge.Data.Classes.Formas
{
    // Trapecio isósceles: lados oblicuos iguales
    public sealed class Trapecio : IForma
    {
        private readonly decimal _baseMayor, _baseMenor, _altura, _ladoOblicuo;
        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal ladoOblicuo)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _ladoOblicuo = ladoOblicuo;
        }
        public string Clave => "trapezoid";
        public decimal Area
        {
            get
            {
                return (_baseMayor + _baseMenor) * _altura / 2m;
            }
        }
        public decimal Perimetro
        {
            get
            {
                return _baseMayor + _baseMenor + 2m * _ladoOblicuo;
            }
        }
    }
}
