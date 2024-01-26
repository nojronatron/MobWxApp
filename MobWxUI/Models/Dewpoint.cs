namespace MobWxUI.Models
{
    public class Dewpoint
    {
        public string? UnitCode { get; set; }
        public double? Value { get; set; }
        public override string ToString()
        {
            string tempUnitCode = string.IsNullOrWhiteSpace(UnitCode) ? ":null" : UnitCode;
            string itemValue = Value?.ToString("F2") ?? "n/a  ";
            string fixedUnitCode = tempUnitCode.Substring(tempUnitCode.IndexOf(':') + 1);
            return $"{itemValue} {fixedUnitCode}";
        }
    }
}
