using System;
using System.IO;
using System.Text;
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
                Console.WriteLine("\n ExeToBase64 coded by Teeknofil, version : 1.1");
                Console.ResetColor();
                Console.WriteLine("\n\t Converts an array of 8-bit unsigned integers \n\t to its equivalent string representation that\n\t is encoded with base-64 digits.");

                if (args.Length == 0)
                {
                    Console.WriteLine("\n\t Drag and Drop file on {0}", AppDomain.CurrentDomain.FriendlyName);
                    Console.WriteLine("\n\t {0} -i <count> -x <file.exe>", AppDomain.CurrentDomain.FriendlyName);
                    Console.ReadKey();
                }
                else
                {
                    string pathFile = Path.GetFullPath(AppDomain.CurrentDomain.FriendlyName);
                    pathFile = pathFile.Substring(0, pathFile.Length - AppDomain.CurrentDomain.FriendlyName.Length);
                    
                    string output = null;
                    string base64String = null;
                    string payloadeCode = null;
                    string nameFile = null;

                    if (args.Length > 2)                   
                    {
                        
                        int count = args.Length;
                        int iteration = 0;

                        for (int i = 0; i < args.Length; i++)
                        {
                            if (args[i].ToLower() == "-i")
                            {                               
                                iteration = int.Parse(args[i + 1]);                            
                            }
                        }

                        for (int i = 0; i < args.Length; i++)
                        {
                            if (args[i].ToLower() == "-x")
                            {                               
                                Byte[] bytes = File.ReadAllBytes(args[i + 1]);

                                for (int x = 0; x < iteration; x++)
                                {
                                    if (x == 0)
                                    {
                                        base64String = Convert.ToBase64String(bytes);
                                    }
                                    else
                                    {
                                        base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(base64String));
                                    }
                                }
                            }
                        }
                       
                        

                        payloadeCode = "List<string> encryptFile = new List<string>() {\"";

                        for (int x = 0; x < base64String.Length; x++)
                        {
                            if (x >= base64String.Length-1)
                            {
                                payloadeCode += base64String[x] + "\"};\n";
                            }
                            else
                            {
                                payloadeCode += base64String[x] + "\",\"";
                            }
                        }

                        payloadeCode += String.Format("string payload = null;");
                        payloadeCode += String.Format("\nforeach (var item in encryptFile) payload += item;");
                        payloadeCode += String.Format("\nfor (int i = 0; i < {0}; i++) payload = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(payload));\n", iteration, base64String);
                                                
                        output = Path.Combine(pathFile,"payload.txt");

                    }
                    else
                    {
                        string s = args[0];
                        nameFile = Path.GetFileNameWithoutExtension(s);
                        output = Path.Combine(pathFile, nameFile + ".txt");                       
                        Byte[] bytes = File.ReadAllBytes(s);
                        payloadeCode = Convert.ToBase64String(bytes);
                    }
                    
                    using (StreamWriter r = new StreamWriter(output))
                    {
                        r.Write(payloadeCode);
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
