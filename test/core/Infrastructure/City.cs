using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ToText.Infrastructure
{
    public class City
    {
        private readonly List<Dojo> dojos;
        private string name;

        public City()
        {
            dojos = new List<Dojo>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public IEnumerable<Dojo> Dojos
        {
            get { return new ReadOnlyCollection<Dojo>(dojos); }
            set
            {
                dojos.Clear();
                dojos.AddRange(value);
            }
        }
    }
}