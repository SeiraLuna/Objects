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
        public static List<string> CommandList = new List<string>()
        {
            "Import",
        };


        public static void Import(string directory)
        {
            string filepath = directory;
            List<string> importList = new List<string>();

            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    importList.Add(sr.ReadLine());
                }
            }

            foreach(string s in importList)
            {
                Console.WriteLine(s);
                Profession profession = new Profession(s);
            }
        }

        public static void Import()
        {
            string filepath = @".\updateClassList.txt";
            Import(filepath);
        }
    }
}
