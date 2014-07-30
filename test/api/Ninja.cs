namespace ToText.Api
{
    public class Ninja
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Hide()
        {
            return "Shhhhhhh......     ";
        }
    }
}