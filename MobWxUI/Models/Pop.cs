namespace MobWxUI.Models
{
    public class Pop
    {
        public string? UnitCode { get; set; }
        public int? Value { get; set; }
        public override string ToString()
        {
            string tempUnitCode = string.IsNullOrWhiteSpace(UnitCode) ? ":null" : UnitCode;
            string? itemValue = Value == null ? "null" : Value.ToString();
            string fixedUnitCode = tempUnitCode.Substring(tempUnitCode.IndexOf(':') + 1);
            return $"{itemValue} {fixedUnitCode}";
        }
    }
}
