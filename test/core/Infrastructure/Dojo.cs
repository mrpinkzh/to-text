namespace ToText.Infrastructure
{
    public class Dojo
    {
        private string name;
        private Ninja master;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Ninja Master
        {
            get { return master; }
            set { master = value; }
        }
    }
}