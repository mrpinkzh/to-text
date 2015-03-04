namespace ToText.Core
{
    public struct MemberValueTuple
    {
        public readonly string name;
        public readonly object value;

        public MemberValueTuple(string name, object value)
        {
            this.name = name;
            this.value = value;
        }
    }
}