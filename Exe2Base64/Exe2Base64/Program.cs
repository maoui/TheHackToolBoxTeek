using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Exe2Base64
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n ExeToBase64 coded by Teeknofil, version : 1.0");
                Console.ResetColor();
                Console.WriteLine("\n\t Converts an array of 8-bit unsigned integers \n\t to its equivalent string representation that\n\t is encoded with base-64 digits.");
                if (args.Length == 0)
                {

                    Console.WriteLine("\n\t Drag and Drop file on {0}", AppDomain.CurrentDomain.FriendlyName);
                    Console.WriteLine("\n\t cli -> {0} file.exe", AppDomain.CurrentDomain.FriendlyName);
                    Console.ReadKey();
                }
                else
                {
                    string s = args[0];
                    string pathFile = Path.GetFullPath(AppDomain.CurrentDomain.FriendlyName);
                    pathFile = pathFile.Substring(0, pathFile.Length - AppDomain.CurrentDomain.FriendlyName.Length);
                    string nameFile = Path.GetFileNameWithoutExtension(s);
                    string output = Path.Combine(pathFile,nameFile + ".txt");

                    Byte[] bytes = File.ReadAllBytes(s);
                    string base64String = Convert.ToBase64String(bytes);

                    using (StreamWriter r = new StreamWriter(output))
                    {
                        r.Write(base64String);
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }            
            
        }
    }
}
