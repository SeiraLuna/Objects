using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Objects
{
    public class UserCommand
    {
        /*
        public UserCommand()
        {
        }
        /*
        public static List<string> CommandList = new List<string>()
        {
            "Load",
        };*/

        public static Dictionary<string, string> CommandList = new Dictionary<string, string>()
        {
            { "Load", "Load" }
        };

       /*
        public static Dictionary<string, Func<string, string>> CommandList = new Dictionary<string, Func<string, string>>()
        {            
            {"Load", (new Func<string,string>(Load))}
        }; */



        public static void Load(string directory)
        {
            string filepath = directory;
            List<string> loadList = new List<string>();

            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    loadList.Add(sr.ReadLine());
                }
            }

            foreach(string s in loadList)
            {
                Console.WriteLine(s);
                Profession profession = new Profession(s);
            }
        }

        public static void Load()
        {
            string filepath = @".\classList.txt";
            Load(filepath);
        }

       // public void CWL()
        //{
         //   Console.WriteLine("looks like it instantiated...");
        //}
    }

}
