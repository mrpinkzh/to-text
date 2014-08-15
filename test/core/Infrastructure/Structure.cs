using System.Collections.Generic;
using NUnit.Framework;

namespace ToText.Infrastructure
{
    public struct Structure
    {
        public string name;
        public List<Floor> floors;

        public Structure(string name, List<Floor> floors)
        {
            this.name = name;
            this.floors = floors;
        }
    }

    public struct Floor
    {
        public int number;

        public Floor(int number)
        {
            this.number = number;
        }
    }
}