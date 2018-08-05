using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Ability
    {
        private static Dictionary<string, Ability> Abilities = new Dictionary<string, Ability>();
        string Name;
        int Value;

        public Ability(string name, int value)
        {
            this.Name = name;
            this.Value = value;
            Abilities.Add(Name, this);
        }

        public static void List()
        {
            Console.WriteLine(String.Join(", ", Abilities.Select(kvp => "\n" + kvp.Key).ToArray()));
        }
    }
}
