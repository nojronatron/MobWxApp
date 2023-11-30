namespace MobWxUI.Models
{
    public class Dewpoint
    {
        public string? UnitCode { get; set; }
        public double? Value { get; set; }
        public override string ToString()
        {
            string tempUnitCode = string.IsNullOrWhiteSpace(UnitCode) ? ":null" : UnitCode;
            string? itemValue = Value == null ? "null" : Value.ToString();
            string fixedUnitCode = tempUnitCode.Substring(tempUnitCode.IndexOf(':') + 1);

            if (itemValue != null && itemValue.IndexOf('.') < 0)
            {
                return $"{itemValue} {fixedUnitCode}";
            }
            
            string trimmedValue = itemValue!.Substring(startIndex: 0, length:itemValue.IndexOf('.') + 3);
            return $"{trimmedValue} {fixedUnitCode}";
        }
    }
}
