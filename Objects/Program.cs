using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Users\rloyd\source\repos\Objects\Objects\classList.txt";
            //string input;
            Queue<string> loadList = new Queue<string>();

            //FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    loadList.Enqueue(sr.ReadLine());
                }
            }
            //input = sr.ReadLine();

            //Profession profession1 = new Profession(input);
           
            while(loadList.Count > 0)
            {
                Profession profession = new Profession(loadList.Dequeue());
            }

            Profession.List();

            //Console.WriteLine(profession1.Name);
            //onsole.WriteLine(profession1.ToString());

            Ability.List();

            Console.ReadKey();
        }

    }
}
