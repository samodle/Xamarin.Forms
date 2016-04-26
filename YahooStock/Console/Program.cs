using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp
{

    class Program
    {
        private const bool DEMO_MODE = true;

        static void Main(string[] args)
        {
            writeIntroToConsole();
            if (DEMO_MODE)
            {
                demoMain();
            }
            else
            {
                stockMain();
            }
            


        }

        static void stockMain()
        {
            Console.WriteLine("Please Enter Stock Symbol...");
        }


        static void demoMain()
        {
            string m1 = "\nType a string of text then press Enter. " +
              "Type '+' anywhere in the text to quit:\n";
            string m2 = "Character '{0}' is hexadecimal 0x{1:x4}.";
            string m3 = "Character     is hexadecimal 0x{0:x4}.";
            char ch;
            int x;
            //
            Console.WriteLine(m1);
            do
            {
                x = Console.Read();
                try
                {
                    ch = Convert.ToChar(x);
                    if (Char.IsWhiteSpace(ch))
                    {
                        Console.WriteLine(m3, x);
                        if (ch == 0x0a)
                            Console.WriteLine(m1);
                    }
                    else
                        Console.WriteLine(m2, ch, x);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("{0} Value read = {1}.", e.Message, x);
                    ch = Char.MinValue;
                    Console.WriteLine(m1);
                }
            } while (ch != '+');
        }
    

        private static void writeIntroToConsole()
        {
       /*     Console.WriteLine("   ____ _             _ ___              _");
            Console.WriteLine(" / ___ || | _ ___ ___| | __ / _ \ _ _  ___ | | _ ___ ___ ");
            Console.WriteLine("  \___ \| __ / _ \ / __ | |/ / | | | | | | |/ _ \| __ / _ \/ __ | ");
            Console.WriteLine("    ___) | || (_) | (__ |   <  | | _ | | | _ | | (_) | || __ /\__ \");
            Console.WriteLine("| ____ / \__\___ / \___ | _ |\_\  \__\_\\__,_ |\___ / \__\___ || ___ / ");
*/

        }
    }
}
