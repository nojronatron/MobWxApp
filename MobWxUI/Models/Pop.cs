namespace MobWxUI.Models
{
    public class Pop
    {
        public string? UnitCode { get; set; }
        public int? Value { get; set; }
        public override string ToString()
        {
            char percentSymbol = '%';
            string? itemValue = Value == null ? "? " : Value.ToString();
            return $"{itemValue}{percentSymbol} Chance";
        }
    }
}
