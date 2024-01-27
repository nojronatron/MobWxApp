using System.Diagnostics;
using WeatherLibrary.Models;

namespace TestWeatherLibrary
{
    public class UnitTestCommonUnits
    {
        private static string UnitCodeCelsius = "wmoUnit:degC";
        private static string UnitCodeFarenheit = "wmoUnit:degF";
        private static string NA = "n/a";

        [Fact]
        public void Test_IntValAllNulls()
        {
            var sut = new IntVal
            {
                UnitCode = null,
                Value = null,
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} {NA}", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_IntValUnitCodeCelsiusValueNull()
        {
            var sut = new IntVal
            {
                UnitCode = UnitCodeCelsius,
                Value = null,
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} C", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_IntValUnitCodeFarenhaeitValueNull()
        {
            var sut = new IntVal
            {
                UnitCode = UnitCodeFarenheit,
                Value = null,
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} F", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_IntValCelsiusValue()
        {
            int value = 77;
            var sut = new IntVal
            {
                UnitCode = UnitCodeCelsius,
                Value = value,
            };
            Assert.Equal($"{value}{sut.DegreeSymbol} C", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_IntValFarenheitValue()
        {
            int value = 77;
            var sut = new IntVal
            {
                UnitCode = UnitCodeFarenheit,
                Value = value,
            };
            Assert.Equal($"{value}{sut.DegreeSymbol} F", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_IntValQC()
        {
            int value = 88;
            var sut = new IntValQC
            {
                UnitCode = null,
                Value = null,
                QualityControl = "QC",
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} {NA}", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new IntValQC
            {
                UnitCode = UnitCodeCelsius,
                Value = null,
                QualityControl = "QC",
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} C", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new IntValQC
            {
                UnitCode = UnitCodeFarenheit,
                Value = null,
                QualityControl = "QC",
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} F", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new IntValQC
            {
                UnitCode = null,
                Value = value,
                QualityControl = "QC",
            };
            Assert.Equal($"{value}{sut.DegreeSymbol} {NA}", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new IntValQC
            {
                UnitCode = UnitCodeCelsius,
                Value = value,
                QualityControl = "QC",
            };
            Assert.Equal($"{value}{sut.DegreeSymbol} C", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new IntValQC
            {
                UnitCode = UnitCodeFarenheit,
                Value = value,
                QualityControl = "QC",
            };
            Assert.Equal($"{value}{sut.DegreeSymbol} F", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_DoubleValALlNulls()
        {
            var sut = new DoubleVal
            {
                UnitCode = null,
                Value = null,
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} {NA}", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_DoubleValUnitCodeCelsiusValueNull()
        {
            var sut = new DoubleVal
            {
                UnitCode = UnitCodeCelsius,
                Value = null,
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} C", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_DoubleValUnitCodeFarenhaeitValueNull()
        {
            var sut = new DoubleVal
            {
                UnitCode = UnitCodeFarenheit,
                Value = null,
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} F", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_DoubleValCelsiusValue()
        {
            double value = 77.77;
            var sut = new DoubleVal
            {
                UnitCode = UnitCodeCelsius,
                Value = value,
            };
            Assert.Equal($"{value:F2}{sut.DegreeSymbol} C", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_DoubleValFarenheitValue()
        {
            double value = 77.77;
            var sut = new DoubleVal
            {
                UnitCode = UnitCodeFarenheit,
                Value = value,
            };
            Assert.Equal($"{value:F2}{sut.DegreeSymbol} F", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_DoubleValQC()
        {
            double value = 88.88;
            var sut = new DoubleValQC
            {
                UnitCode = null,
                Value = null,
                QualityControl = "QC",
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} {NA}", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new DoubleValQC
            {
                UnitCode = UnitCodeCelsius,
                Value = null,
                QualityControl = "QC",
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} C", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new DoubleValQC
            {
                UnitCode = UnitCodeFarenheit,
                Value = null,
                QualityControl = "QC",
            };
            Assert.Equal($"{NA}{sut.DegreeSymbol} F", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new DoubleValQC
            {
                UnitCode = null,
                Value = value,
                QualityControl = "QC",
            };
            Assert.Equal($"{value:F2}{sut.DegreeSymbol} {NA}", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new DoubleValQC
            {
                UnitCode = UnitCodeCelsius,
                Value = value,
                QualityControl = "QC",
            };
            Assert.Equal($"{value:F2}{sut.DegreeSymbol} C", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            sut = new DoubleValQC
            {
                UnitCode = UnitCodeFarenheit,
                Value = value,
                QualityControl = "QC",
            };
            Assert.Equal($"{value:F2}{sut.DegreeSymbol} F", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_PresentWeatherVariousNullInputs()
        {
            var sut = new PresentWeather();
            Assert.Equal($"Raw METAR: {NA}...Weather {NA} {NA} {NA}.", sut.ToString());

            var intensity = "Light";
            sut = new PresentWeather
            {
                Intensity = intensity,
            };
            Assert.Equal($"Raw METAR: {NA}...Weather Light {NA} {NA}.", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            var modifier = "Freezing";
            sut = new PresentWeather
            {
                Intensity = intensity,
                Modifier = modifier,
            };
            Assert.Equal($"Raw METAR: {NA}...Weather Light Freezing {NA}.", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            var weather = "Rain";
            sut = new PresentWeather
            {
                Intensity = intensity,
                Modifier = modifier,
                Weather = weather,
            };
            Assert.Equal($"Raw METAR: {NA}...Weather Light Freezing Rain.", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");

            var rawString = "FZRA";
            sut = new PresentWeather
            {
                Intensity = intensity,
                Modifier = modifier,
                Weather = weather,
                RawString = rawString,
            };
            Assert.Equal($"Raw METAR: FZRA...Weather Light Freezing Rain.", sut.ToString());
            Debug.WriteLine($"Test returned: {sut}");
        }

        [Fact]
        public void Test_ProbabilityOfPrecipitation()
        {
            var pop = new Pop
            {
                UnitCode = "wmoUnit:percent",
                Value = 100,
            };

            var pop2 = new Pop();
            pop2.UnitCode = "wmoUnit:percent";
            pop2.Value = 100;
        }
    }
}
