namespace WeatherLibrary.Models
{
    public abstract class CommonUnitsModel
    {
        public const string NotAvailable = "n/a";
        public char DegreeSymbol { get; set; } = '\u00B0';
        public string? UnitCode { get; set; }
    }

    public class IntVal : CommonUnitsModel
    {
        public int? Value { get; set; }

        public override string ToString()
        {
            string itemValue = Value is null ? NotAvailable : $"{Value}";
            int index = UnitCode?.IndexOf(':') ?? -1;
            string fixedUnitCode = index != -1 ? UnitCode!.Substring(UnitCode.Length - 1) : NotAvailable;
            return $"{itemValue}{DegreeSymbol} {fixedUnitCode}";
        }
    }

    public class IntValQC : IntVal
    {
        public string QualityControl { get; set; } = string.Empty;

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class DoubleVal : CommonUnitsModel
    {
        public double? Value { get; set; }

        public override string ToString()
        {
            string itemValue = Value is null ? NotAvailable : $"{Value:F2}";
            int index = UnitCode?.IndexOf(':') ?? -1;
            string fixedUnitCode = index != -1 ? UnitCode!.Substring(UnitCode.Length - 1) : NotAvailable;
            return $"{itemValue}{DegreeSymbol} {fixedUnitCode}";
        }
    }

    public class DoubleValQC : DoubleVal
    {
        public string QualityControl { get; set; } = string.Empty;

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class PresentWeather
    {
        private const string _notAvailable = "n/a";
        public string Intensity { get; set; } = _notAvailable;
        public string Modifier { get; set; } = _notAvailable;
        public string Weather { get; set; } = _notAvailable;
        public string RawString { get; set; } = _notAvailable;

        public override string ToString()
        {
            return $"Raw METAR: {RawString}...Weather {Intensity} {Modifier} {Weather}.";
        }
    }

    public class CloudLayer
    {
        public const string NoReport = "No report.";
        public IntVal @Base { get; set; } = new IntVal();
        public CloudLayerAmount Amount { get; set; }

        public override string ToString()
        {
            string tempBase = NoReport;

            if (Base.Value is not null)
            {
                tempBase = $"{Base.Value}";
            }

            string tempAmount = Amount == CloudLayerAmount.NoReport ? NoReport : Amount.ToString();
            return $"{tempBase} {Amount}";
        }
    }

    public enum CloudLayerAmount
    {
        NoReport,
        OVC,
        BKN,
        SCT,
        FEW,
        SKC,
        CLR,
        VV
    }
}
