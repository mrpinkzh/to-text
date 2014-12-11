namespace ToText.Core
{
    public struct PropertyValueTuple
    {
        public readonly string name;
        public readonly dynamic value;

        public PropertyValueTuple(string name, dynamic value)
        {
            this.name = name;
            this.value = value;
        }
    }
}