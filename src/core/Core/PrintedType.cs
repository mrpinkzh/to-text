namespace ToText.Core
{
    public struct PrintedType
    {
        public readonly string value;
        public readonly int length;

        public PrintedType(string value, int length)
        {
            this.value = value;
            this.length = length;
        }
    }
}