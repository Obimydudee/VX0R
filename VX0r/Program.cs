using System;

namespace VX0r
{
    internal class Program
    {
        public static utils _utils = new utils();
        static void Main(string[] args)
        {
            string[] array = new string[]
            {
            "Xor Encode", "Xor Decode", "Exit"
            };

            int num = 0;
            while (true)
            {
                Console.Title = "| VX0R |";
                Console.Clear();
                for (int j = 0; j < array.Length; j++)
                {
                    if (j == num)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("> ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine(array[j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                switch (System.Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (num > 0)
                        {
                            num--;
                            System.Console.WriteLine(num);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (num < array.Length - 1)
                        {
                            num++;
                            System.Console.WriteLine(num);
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (num == array.Length - 1)
                        {
                            System.Console.WriteLine("Exiting program.");
                            return;
                        }
                        switch (num)
                        {
                            case 0:
                                XorEnc();
                                break;
                            case 1:
                                XorDec();
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        public static void XorDec()
        {
            Console.Clear();
            Console.Write("Enter XorHexed string: ");
            string inp = Console.ReadLine();
            Console.Clear();
            Console.Write("Enter key: ");
            string key = Console.ReadLine();
            Console.WriteLine($"\n{_utils.Dec(inp, key)}");
            Console.ReadKey();
        }

        public static void XorEnc()
        {
            Console.Clear();
            Console.Write("Enter string: ");
            string inp = Console.ReadLine();
            Console.Clear();
            Console.Write("Enter key: ");
            string key = Console.ReadLine();
            Console.WriteLine($"\n{_utils.Enc(inp, key)}");
            Console.ReadKey();
        }

    }
}
