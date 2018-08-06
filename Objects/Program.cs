using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string filepath = @".\classList.txt";
            Queue<string> loadList = new Queue<string>();

            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    loadList.Enqueue(sr.ReadLine());
                }
            }
           */
            /*
             while(loadList.Count > 0)
             {
                 Profession profession = new Profession(loadList.Dequeue());
             }
             */

            Console.WriteLine("Please enter a commmand: ");
            string input = Console.ReadLine();

            if (input.StartsWith("/"))
                Execute(input.Substring(1));

            Profession.List();
            Ability.List();

            Console.ReadKey();
        }
        
        public static void Execute(string command)
        {
            UserCommand Commands = new UserCommand();
            //Commands.CWL();

            if (command.Contains(" "))
            {
                try
                {
                    string filePath = command.Substring(command.IndexOf(" ") + 1);
                    command = command.Substring(0, command.IndexOf(" "));
                    // below conditional works, but subsequent invoke returns error if case does not match.
                    //if (UserCommand.CommandList.FindIndex(x => x.Equals(command, StringComparison.OrdinalIgnoreCase)) > -1)
                    if (UserCommand.CommandList.Any(x => x.Key.Equals(command, StringComparison.OrdinalIgnoreCase)))
                    //if (UserCommand.CommandList.Contains(command))
                    {
                        //UserCommand.CommandList[command].DynamicInvoke(filePath);                   
                        Commands.GetType().GetMethod(command, new Type[] { typeof(string) }).Invoke(Commands, new object[] { filePath });
                        //typeof(UserCommand).GetMethod(command).Invoke(null, new[] { filePath });
                    }
                }

            }
            //else if (Command.CommandList.ContainsKey(command))
            //Command.CommandList[command].DynamicInvoke();
            //else if(UserCommand.CommandList.FindIndex(x => x.Equals(command, StringComparison.OrdinalIgnoreCase)) > -1)
            else if (UserCommand.CommandList.Any(x => x.Key.Equals(command, StringComparison.OrdinalIgnoreCase)))
            //else if (UserCommand.CommandList.Contains(command))
            {
                var cmd = from x in UserCommand.CommandList where x.Key.Equals(command, StringComparison.OrdinalIgnoreCase) select x.Key;
                Commands.GetType().GetMethod(UserCommand.CommandList[command], new Type[0]).Invoke(Commands, new object[0]);
                //typeof(UserCommand).GetMethod(command).Invoke(null, new[] { typeof(Nullable) });
            }
            else
                Console.WriteLine("Invalid input");
        }

    }
}
