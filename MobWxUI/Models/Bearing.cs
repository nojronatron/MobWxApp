namespace MobWxUI.Models
{
    public class Bearing
    {
        public string? UnitCode { get; set; }
        public int? Value { get; set; } = 0;
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(UnitCode))
            {
                UnitCode = ":null";
            }

            string? itemValue = Value == null ? "null" : Value.ToString();
            string fixedUnitCode = UnitCode.Substring(UnitCode.IndexOf(':') + 1);
            return $"{itemValue} {fixedUnitCode}";
        }
    }
}
