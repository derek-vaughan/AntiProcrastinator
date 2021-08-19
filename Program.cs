using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AntiProcrastinator
{
    class Program
    {
        static void Main(string[] args)
        {
            const String filePath = @"C:\Windows\System32\drivers\etc\hosts";
            Menu(filePath);

            Console.ReadLine();
        }

        static void Menu(String filePath)
        {
            string userInput = "";
            int menuOption = 0;

            while ((!String.Equals(userInput, "1")) && (!String.Equals(userInput, "2")))
            {
                Console.WriteLine("Enter 1 to Block Websites");
                Console.WriteLine("Enter 2 to Unblock Websites");

                userInput = Console.ReadLine();
                Console.WriteLine("You entered: " + userInput);
                Console.WriteLine(String.Equals(userInput, "1"));
            }

            menuOption = Convert.ToInt32(userInput);

            if (menuOption == 1)
            {
                StartWebsiteBlocker(filePath);
            }
            else
            {
                EndWebsiteBlocker(filePath);
            }
        }

        static void StartWebsiteBlocker(String filePath)
        {
            Console.WriteLine("Let's get to work.");
            Console.WriteLine("Blocking...");

            StreamWriter sw = new StreamWriter(filePath, true);
            String website = "\n 127.0.0.0 www.solitaired.com\n 127.0.0.0 https://www.solitaired.com\n 127.0.0.0 solitaired.com\n 127.0.0.0 https://solitaired.com\n 127.0.0.0 http://solitaired.com\n 127.0.0.0 https://solitaired.com/";
            sw.Write(website);
            sw.Close();

            Console.WriteLine("Website has been blocked");
        }

        static void EndWebsiteBlocker(String filePath)
        {
            Console.WriteLine("Unblocking...");

            List<string> lines = File.ReadAllLines(filePath).ToList();
            File.WriteAllLines(filePath, lines.GetRange(0, lines.Count - 6).ToArray());
        }

        static void TestFunction()
        {
            Console.WriteLine("test function");
        }
    }
}
