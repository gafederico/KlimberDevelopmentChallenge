using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Cuadrado, 5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 1),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Circulo, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Circulo, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        #region Nuevos tests

        [TestCase]
        public void TestResumenListaVaciaEnItaliano()
        {
            var resumen = FormaGeometrica.Imprimir(new List<FormaGeometrica>(), FormaGeometrica.Italiano);
            Assert.AreEqual("<h1>Lista vuota di forme!</h1>", resumen);
        }

        [TestCase]
        public void TestResumenConUnRectangulo()
        {
            var formas = new List<FormaGeometrica>
            {
                // Rectángulo 4 x 2  -> Área 8, Perímetro 12
                new FormaGeometrica(4m, 2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Rectángulo | Area 8 | Perimetro 12 <br/>TOTAL:<br/>1 formas Perimetro 12 Area 8",
                resumen);
        }

        [TestCase]
        public void TestResumenConUnTrapezioEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                // Trapecio isósceles: B=10, b=6, h=4, lado=3 -> Área 32, Perímetro 22
                new FormaGeometrica(baseMayor: 10m, baseMenor: 6m, altura: 4m, ladoOblicuo: 3m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Italiano);

            Assert.AreEqual(
                "<h1>Report delle Forme</h1>1 Trapezio | Area 32 | Perimetro 22 <br/>TOTAL:<br/>1 forme Perimetro 22 Area 32",
                resumen);
        }

        [TestCase]
        public void TestResumenRectanguloYTrapecioEnIngles()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(4m, 2m), // Rectangle:  Area 8,  Perimeter 12
                new FormaGeometrica(baseMayor: 10m, baseMenor: 6m, altura: 4m, ladoOblicuo: 3m) // Trapezoid: Area 32, Perimeter 22
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>1 Rectangle | Area 8 | Perimeter 12 <br/>1 Trapezoid | Area 32 | Perimeter 22 <br/>TOTAL:<br/>2 shapes Perimeter 34 Area 40",
                resumen);
        }

        #endregion

    }
}
