using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Profession
    {
        public static Dictionary<string, Profession> Professions = new Dictionary<string, Profession>();
        public string Name;
        Dictionary<string, object> AttributeModifers;
        Dictionary<string, object> Abilities; // consider second Populate function

        public Profession(string properties)
        {
            this.Name = properties.Substring(0, properties.IndexOf(";"));
            this.AttributeModifers = new Dictionary<string, object>();
            this.Abilities = new Dictionary<string, object>();
            Professions.Add(this.Name, this);

            Populate(Parse(';', ref properties), this.AttributeModifers);
            Populate(Parse(';', ref properties), this.Abilities);
        }

        private void Populate(string input, Dictionary<string, object> item)
        {
            try
            {
                if (!input.StartsWith(";"))
                {
                    if (input.Contains(".") && input.IndexOf(".") < input.IndexOf(","))
                        item.Add(input.Substring(0, input.IndexOf(".")), input.Substring(input.IndexOf(".") + 1, input.IndexOf(",") - input.IndexOf(".") - 1));
                    else
                        item.Add(input.Substring(0, input.IndexOf(",")), new Ability(input.Substring(0, input.IndexOf(",")), 0));
                    Populate(input.Substring(input.IndexOf(",")+1), item);
                }
            }
            catch
            {
                return;
            }
        }

        public override string ToString()
        {
            return ($"{this.Name}" +
                $" {string.Join(", ", this.AttributeModifers.Select(kvp => kvp.Key + ": " + kvp.Value).ToArray())}" +
                $" {string.Join("", this.Abilities.Select(kvp => "\n" + kvp.Key + ": " + kvp.Value).ToArray())}");
        }

        private string Parse(char parser, ref string parameters)
        {
            parameters = parameters.Substring(parameters.IndexOf(parser) + 1);
            return parameters;
        }

        public static void List()
        {
            Console.WriteLine(String.Join(",\n", Professions.Select(kvp => kvp.Key).ToArray()));
        }
    }
}
