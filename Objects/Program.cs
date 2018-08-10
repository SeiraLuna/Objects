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
            
            try
            {
                if (command.Contains(" "))
                {
                    string filePath = command.Substring(command.IndexOf(" ") + 1);
                    command = command.Substring(0, command.IndexOf(" "));
                    int commandIndex = UserCommand.CommandList.IndexOf((from x in UserCommand.CommandList where x.Equals(command, StringComparison.OrdinalIgnoreCase) select x).First());         
                    Commands.GetType().GetMethod(UserCommand.CommandList[commandIndex], new Type[] { typeof(string) }).Invoke(Commands, new object[] { filePath });
                }
                else
                {
                    int commandIndex = UserCommand.CommandList.IndexOf((from x in UserCommand.CommandList where x.Equals(command, StringComparison.OrdinalIgnoreCase) select x).First());
                    Commands.GetType().GetMethod(UserCommand.CommandList[commandIndex], new Type[0]).Invoke(Commands, new object[0]);
                }
            }
            catch
            {
                Console.WriteLine("Invalid input");
            } 
        }

        private static void ParseCommand (ref List<string> commandSet, string commandString)
        {
            commandSet.Add(commandString.Substring(0, commandString.IndexOf(" ")));
            ParseCommand(ref commandSet, commandString.Substring(commandString.IndexOf(" ") + 1));
        }
    }
}
