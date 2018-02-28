using System;
using System.IO;
using System.Windows.Forms;

namespace NetAssemblyDetect
{
    class Program
    {
        public static bool IsManagedAssembly(string fileName)
        {
            using (Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (BinaryReader binaryReader = new BinaryReader(fileStream))
            {
                if (fileStream.Length < 64)
                {
                    return false;
                }

                //PE Header starts @ 0x3C (60). Its a 4 byte header.
                fileStream.Position = 0x3C;
                uint peHeaderPointer = binaryReader.ReadUInt32();
                if (peHeaderPointer == 0)
                {
                    peHeaderPointer = 0x80;
                }

                // Ensure there is at least enough room for the following structures:
                //     24 byte PE Signature & Header
                //     28 byte Standard Fields         (24 bytes for PE32+)
                //     68 byte NT Fields               (88 bytes for PE32+)
                // >= 128 byte Data Dictionary Table
                if (peHeaderPointer > fileStream.Length - 256)
                {
                    return false;
                }

                // Check the PE signature.  Should equal 'PE\0\0'.
                fileStream.Position = peHeaderPointer;
                uint peHeaderSignature = binaryReader.ReadUInt32();
                if (peHeaderSignature != 0x00004550)
                {
                    return false;
                }

                // skip over the PEHeader fields
                fileStream.Position += 20;

                const ushort PE32 = 0x10b;
                const ushort PE32Plus = 0x20b;

                // Read PE magic number from Standard Fields to determine format.
                var peFormat = binaryReader.ReadUInt16();
                if (peFormat != PE32 && peFormat != PE32Plus)
                {
                    return false;
                }

                // Read the 15th Data Dictionary RVA field which contains the CLI header RVA.
                // When this is non-zero then the file contains CLI data otherwise not.
                ushort dataDictionaryStart = (ushort)(peHeaderPointer + (peFormat == PE32 ? 232 : 248));
                fileStream.Position = dataDictionaryStart;

                uint cliHeaderRva = binaryReader.ReadUInt32();
                if (cliHeaderRva == 0)
                {
                    return false;
                }

                return true;
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n NetAssemblyDetect coded by Teeknofil, version : 1.0");
            Console.ResetColor();
            Console.WriteLine("\n\t Determined Assembly .Net\n\n");
            if (args.Length == 0)
            {

                Console.WriteLine("\n\t Drag and Drop file on {0}", AppDomain.CurrentDomain.FriendlyName);
                Console.WriteLine("\n\t cli -> {0} file.exe", AppDomain.CurrentDomain.FriendlyName);
                Console.ReadKey();
            }
            else
            {
                try
                {
                    bool test = IsManagedAssembly(args[0]);

                    if (test)
                    {
                        Console.WriteLine("  it's a Assembly .Net");
                        Console.WriteLine("  Reloc : No");
                    }
                    else
                    {
                        Console.WriteLine("  It's Native Code");
                        Console.WriteLine("  Reloc : Yes");
                    }
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
