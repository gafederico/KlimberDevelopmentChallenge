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
        private readonly decimal _baseMayor, _baseMenor, _altura, _ladoOblicuo; // trapecio

        // Constructor legacy existente:

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormaGeometrica"/> con el tipo y la dimensión especificados.
        /// </summary>
        /// <param name="tipo"> El tipo de la forma geométrica. Debe ser una de las constantes predefinidas: <c>Cuadrado</c>,
        /// <c>TrianguloEquilatero</c> o <c>Circulo</c>.</param>
        /// <param name="ancho">La dimensión de la forma. Para <c>Cuadrado</c> y <c>TrianguloEquilatero</c>, representa la longitud del lado.
        /// Para <c>Circulo</c>, representa el diámetro.</param>
        /// <exception cref="ArgumentException">Se lanza si <paramref name="tipo"/> no es un tipo de forma válido o si el constructor es incompatible 
        /// con la forma especificada.</exception>

        public FormaGeometrica(int tipo, decimal ancho)
        {
            if (tipo == Cuadrado || tipo == TrianguloEquilatero)
                _lado = ancho;
            else if (tipo == Circulo)
                _diametro = ancho;
            else
                throw new ArgumentException("Constructor incompatible para esta forma");
            Tipo = tipo;
        }

        // De ahora en mas, lo mejor sería tener un constructor para cada forma.
        // No sería mas necesario una clave, y lo hace mas legible.

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FormaGeometrica"/> como rectangulo.
        /// </summary>
        /// <param name="ancho">El ancho del rectangulo.</param>
        /// <param name="alto">El alto del rectangulo.</param>
        public FormaGeometrica(decimal ancho, decimal alto)
        {
            Tipo = Rectangulo;
            _ancho = ancho;
            _alto = alto;
        }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FormaGeometrica"/> como trapecio.
        /// </summary>
        /// <param name="baseMayor">La longitud de la base mayor del trapecio.</param>
        /// <param name="baseMenor">La longitud de la base menor del trapecio.</param>
        /// <param name="altura">La altura del trapecio, medida de forma perpendicular a las bases.</param>
        /// <param name="ladoOblicuo">La longitud de uno de los lados no paralelos (lado oblicuo) del trapecio.</param>
        public FormaGeometrica(decimal baseMayor, decimal baseMenor, decimal altura, decimal ladoOblicuo)
        {
            Tipo = Trapecio;
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _ladoOblicuo = ladoOblicuo;
        }

        // Adaptador hacia IForma
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

        // **Firma original**: mantiene comportamiento de los tests actuales
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            // Parse de FormaGeometrica a la interfaz IForma
            var iFormas = formas?.Select(f => f.ToIForma()).ToList() ?? new List<IForma>();

            var localization = FormaLocalizationFactory.From(idioma);
            var reporteFormasService = new ReporteFormasService(localization);

            return reporteFormasService.Print(iFormas);
        }

        // Métodos legacy ya no se usan por el reporte, pero se mantienen por compat (si alguien los llama directo).
        public decimal CalcularArea() => ToIForma().Area;
        public decimal CalcularPerimetro() => ToIForma().Perimetro;
    }
}
