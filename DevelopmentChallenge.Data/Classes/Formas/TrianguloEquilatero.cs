using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class TrianguloEquilatero : IForma
    {
        private readonly decimal _lado;
        public TrianguloEquilatero(decimal side) { _lado = side; }
        public string Clave => "triangle";
        public decimal Area
        {
            get
            {
                return (_lado * _lado * (decimal)Math.Sqrt(3)) / 4m;
            }
        }
        public decimal Perimetro
        {
            get
            {
                return 3 * _lado;
            }
        }
    }
}
