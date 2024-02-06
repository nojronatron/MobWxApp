namespace MobWxUI.Models
{
    public class Rh
    {
        public string? UnitCode { get; set; }
        public int? Value { get; set; }
        public override string ToString()
        {
            string fixedUnitCode = "%";
            string ? itemValue = Value == null ? "?" : Value.ToString();
            return $"{itemValue}{fixedUnitCode}";
        }
    }
}
