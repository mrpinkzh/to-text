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

        public override string ToString()
        {
            return string.Format("{{name: {0}, value: {1}}}", name, value);
        }
    }
}