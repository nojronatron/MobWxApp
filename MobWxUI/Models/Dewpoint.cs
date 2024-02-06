namespace MobWxUI.Models
{
    public class Dewpoint
    {
        public string? UnitCode { get; set; }
        public double? Value { get; set; }
        public override string ToString()
        {
            char degreeSymbol = '°';
            string fixedUnitCode = string.IsNullOrWhiteSpace(UnitCode) 
                ? $"{degreeSymbol}?" 
                : $"{degreeSymbol}{UnitCode.Substring(UnitCode.IndexOf(':')+4, 1).ToUpper()}";
            string itemValue = Value?.ToString("F1") ?? "n/a  ";
            return $"{itemValue}{fixedUnitCode}";
        }
    }
}
