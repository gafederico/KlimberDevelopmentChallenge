# Klimber Development Challenge

Repositorio de la implementación del desafío de refactorización de reportes de formas geométricas.

## 📋 Descripción

Este proyecto presenta una solución refactorizada para el módulo que genera reportes basados en una colección de formas geométricas.
Las mejoras clave incluyen:

- Separación clara entre modelo de formas, motor de reportes y localización.

- Soporte para nuevas formas geométricas (Rectángulo, Trapecio).

- Soporte para múltiples idiomas mediante recursos (.resx): Español, Inglés, Italiano.

- Firma original del método preservada (public static string Imprimir(List<FormaGeometrica> formas, int idioma)) para compatibilidad.

- Buena cobertura de tests unitarios (NUnit) que garantizan el comportamiento esperado en todos los idiomas y formas.

## 📁 Estructura del proyecto
```txt
DevelopmentChallenge.Data/
├── Classes/
│   ├── FormaGeometrica.cs                 ← Punto de entrada / compatibilidad legacy
│   ├── Formas/
│   │   ├── IForma.cs                      ← Interfaz de formas geométricas
│   │   ├── ReporteFormasService.cs        ← Motor de generación de reportes
│   │   ├── Cuadrado.cs
│   │   ├── Circulo.cs
│   │   ├── TrianguloEquilatero.cs
│   │   ├── Rectangulo.cs
│   │   └── Trapecio.cs
│   ├── Localization/
│   │   ├── IFormaLocalization.cs          ← Interfaz de localización
│   │   ├── LocalizationResx.cs            ← Implementación basada en .resx
│   │   ├── FormaLocalizationFactory.cs    ← Factory que resuelve la localización según el idioma
│   │   └── Resources/
│   │       ├── Report.resx                ← Base (neutral)
│   │       ├── Report.es.resx             ← Español
│   │       ├── Report.en.resx             ← Inglés
│   │       └── Report.it.resx             ← Italiano

DevelopmentChallenge.Data.Tests/
└── DataTests.cs                           ← Tests originales + nuevos dentro de su respectiva "region"
```

## ✅ Uso
Cloná este repositorio:
 ```git clone https://github.com/gafederico/KlimberDevelopmentChallenge.git```

Para generar un reporte, utilizá la clase FormaGeometrica:
```csharp
var formas = new List<FormaGeometrica>
{
    new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
    new FormaGeometrica(FormaGeometrica.Circulo, 3)
    // etc.
};
string reporte = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);
Console.WriteLine(reporte);
```
