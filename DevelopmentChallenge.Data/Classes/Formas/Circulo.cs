using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    public class Circulo : IForma
    {
        private readonly decimal _diametro;
        public Circulo(decimal diametro) { _diametro = diametro; }
        public string Clave => "circle";
        public decimal Area
        {
            get
            {
                return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
            }
        }
        public decimal Perimetro
        {
            get { return (decimal)Math.PI * _diametro; }
        }
    }
}
