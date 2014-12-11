namespace ToText.Core
{
    public struct MemberValueTuple
    {
        public readonly string name;
        public readonly dynamic value;

        public MemberValueTuple(string name, dynamic value)
        {
            this.name = name;
            this.value = value;
        }
    }
}