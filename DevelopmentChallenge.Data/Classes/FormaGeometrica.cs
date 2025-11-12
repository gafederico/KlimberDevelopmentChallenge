/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos. => Se implementaron interfaces
 * Implementar la forma Trapecio/Rectangulo. => Agregados como clases que implementan la interfaz
 * Agregar el idioma Italiano (o el deseado) al reporte. => Se agregó ILocalization, se exportó los recursos a .resx y se implementó el idioma Italiano 🤌
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Classes.Formas;
using DevelopmentChallenge.Data.Classes.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas
        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;
        public const int Rectangulo = 5;
        #endregion

        #region Idiomas
        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;
        #endregion

        // --- Adaptador legacy ---
        public int Tipo { get; private set; }

        // parámetros posibles
        private readonly decimal _lado;                   // cuadrado, triángulo
        private readonly decimal _diametro;               // círculo
        private readonly decimal _ancho, _alto;           // rectángulo
        private readonly decimal _baseMayor, _baseMenor, _altura, _ladoOblicuo; // trapecio isósceles

        // Constructores legacy existentes:
        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            // compat: los tests viejos usan este ctor:
            if (tipo == Cuadrado || tipo == TrianguloEquilatero) _lado = ancho;
            else if (tipo == Circulo) _diametro = ancho;
            else throw new ArgumentException("Constructor incompatible para esta forma");
        }

        // Nuevos para rectángulo
        public FormaGeometrica(decimal ancho, decimal alto)
        {
            Tipo = Rectangulo;
            _ancho = ancho; _alto = alto;
        }

        // Nuevos para trapecio isósceles
        public FormaGeometrica(decimal baseMayor, decimal baseMenor, decimal altura, decimal ladoOblicuo)
        {
            Tipo = Trapecio;
            _baseMayor = baseMayor; _baseMenor = baseMenor; _altura = altura; _ladoOblicuo = ladoOblicuo;
        }

        // Adaptador hacia IShape
        internal IForma ToIForma()
        {
            IForma forma;
            switch (Tipo)
            {
                case Cuadrado:
                    forma = new Cuadrado(_lado);
                    break;
                case Rectangulo:
                    forma = new Rectangulo(_ancho, _alto);
                    break;
                case Trapecio:
                    forma = new Trapecio(_baseMayor, _baseMenor, _altura, _ladoOblicuo);
                    break;
                case Circulo:
                    forma = new Circulo(_diametro);
                    break;
                case TrianguloEquilatero:
                    forma = new TrianguloEquilatero(_lado);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Forma desconocida");
            }
            return forma;
        }

        // **Firma original**: mantiene comportamiento/strings de los tests actuales
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var shapes = formas?.Select(f => f.ToIForma()).ToList() ?? new List<IForma>();
            var loc = FormaLocalizationFactory.From(idioma);
            var svc = new ReporteFormasService(loc);
            return svc.Print(shapes);
        }

        // Métodos legacy ya no se usan por el reporte, pero se mantienen por compat (si alguien los llama directo).
        public decimal CalcularArea() => ToIForma().Area;
        public decimal CalcularPerimetro() => ToIForma().Perimetro;
    }
}
