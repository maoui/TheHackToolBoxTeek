using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exe2Bytes
{
    class Program
    {
        static void Main(string[] args)
        {

            if (Regex.IsMatch(args[0], @".\.exe$") | Regex.IsMatch(args[0], @".\.dll$"))
            {                
                try
                {  
                    byte[] bytes = System.IO.File.ReadAllBytes(args[0]);                
                    string shellcode = "0x" + BitConverter.ToString(bytes).Replace("-", ",0x");
                
                    if (args[1].ToLower() == "-o")
                    {
                        System.IO.StreamWriter file = new System.IO.StreamWriter(args[2]);
                        file.Write(shellcode);
                        Console.WriteLine("\n\t File Writed -> "+System.IO.Path.GetFullPath(args[2]));                       
                    }                    
                    else if (args[1] == "R")
                    {
                       Console.WriteLine(shellcode);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\n\tError!\n\t-h option for display help");
                }

            }
            else if (args[0].ToLower() == "-h" | args[0].ToLower() == "--help" | args[0].ToLower() == "/?" |  args[0].ToLower() == "/help")
            {
                Console.WriteLine("\n\tUsing :\n\n\t  exe2Bytes [*.exe|*.dll] [option 2]");
                Console.WriteLine("\n\t -h option for display help");
                Console.WriteLine("\n\t  R display bytes");
                Console.WriteLine("\n\t -o : writing bytes in txt file");
                Console.WriteLine("\n\tExample :");
                Console.WriteLine("\n\t exe2Bytes file.exe R");
                Console.WriteLine("\t exe2Bytes file.exe -o bytes.txt");
            }
            else
            {
                Console.WriteLine("\n\t -h option for display help");
            }         
        }
    }
}
