using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Objects
{
    public class UserCommand
    {      
        public static List<string> CommandList = new List<string>()
        {
            "Import",
            "Export",
            "Load",
            "Save",
        };

        public static void Import()
        {
            string filepath = @".\updateClassList.txt";
            Import(filepath);
        }

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

            using (StreamWriter sw = new StreamWriter(@".\classList.txt", true))
            {
                foreach (string s in importList)
                {
                    Profession profession = new Profession(s);
                    sw.WriteLine(s);
                }
            }            
        }
        //Parameter free function plugs local directory export.txt as the default output file
        public static void Export()
        {
            string filepath = @".\export.txt";
            Export(filepath);
        }

        public static void Export(string filepath)
        {
            List<string> exportList = new List<string>();
            //Extract data from source and store in exportList
            using (StreamReader sr = new StreamReader(@".\classList.txt"))
            {
                while (!sr.EndOfStream)
                {
                    exportList.Add((string)sr.ReadLine());
                }
            }
            //Confirm that input directory exists and create it if it does not
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath.Substring(0,filepath.LastIndexOf('\\')));
            //Create or open output file in directory and write data from exportList (obtained from source) to the output file.
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))                
            {
                StreamWriter sw = new StreamWriter(fs);
                foreach (string s in exportList)
                {
                    sw.WriteLine(s);
                }
                sw.Close();
            }
        }

        private static int Occurs (string character, string searchString)
        {
            int count = 0;
            for(var i = 0; i < searchString.Length - character.Length; i++)
            {
                if (searchString.Substring(i, character.Length) == character)
                    ++count;
            }
            return count;
        }
    }
}
