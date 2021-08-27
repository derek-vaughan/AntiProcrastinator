using System;
using System.Collections;
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

            while ((!String.Equals(userInput, "1")) && (!String.Equals(userInput, "2")) && (!String.Equals(userInput, "3")))
            {
                Console.WriteLine("Enter 1 to Start Blocking Websites");
                Console.WriteLine("Enter 2 to Unblock Websites");
                Console.WriteLine("Enter 3 to Exit the Program");

                userInput = Console.ReadLine();
            }

            menuOption = Convert.ToInt32(userInput);

            if (menuOption == 1)
            {
                StartWebsiteBlocker(filePath);
            }
            else if (menuOption == 2)
            {
                EndWebsiteBlocker(filePath);
            }
            else
            {
                Console.WriteLine("Goodbye.");
            }

        }

        static void StartWebsiteBlocker(String filePath)
        {
            ArrayList websitesToBlock = getListOfWebsitesToBlock();

            foreach (var item in websitesToBlock)
            {
                Console.WriteLine("Item: " + item);
            }

            Console.ReadLine(); /////////////////

            Console.WriteLine("Let's get to work.");
            Console.WriteLine("Blocking...");

            StreamWriter sw = new StreamWriter(filePath, true);
            String website = "\n 127.0.0.0 www.solitaired.com\n 127.0.0.0 https://www.solitaired.com\n 127.0.0.0 solitaired.com\n 127.0.0.0 https://solitaired.com\n 127.0.0.0 http://solitaired.com\n 127.0.0.0 https://solitaired.com/";
            sw.Write(website);
            sw.Close();

            Console.WriteLine("Website has been blocked");
        }

        static ArrayList getListOfWebsitesToBlock()
        {
            bool addNewWebsite = true;
            string userInput = "";
            ArrayList websitesToBlock = new ArrayList();

            Console.WriteLine("Enter a website name, without the \"www.\" or \".com\", ");
            Console.WriteLine("For example, you can enter: facebook");
            Console.WriteLine("Or, enter an empty string to finish adding websites.");

            while (addNewWebsite)
            {
                Console.Write("Website Name: ");
                userInput = Console.ReadLine();

                if (websitesToBlock.Count == 0 && string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Please enter a non-empty string.");
                }
                else if (string.IsNullOrWhiteSpace(userInput))
                {
                    addNewWebsite = false;
                }
                else
                {
                    websitesToBlock.Add(userInput);
                }
            }

            return websitesToBlock;
        }

        static void EndWebsiteBlocker(String filePath)
        {
            Console.WriteLine("Unblocking...");

            List<string> lines = File.ReadAllLines(filePath).ToList();
            File.WriteAllLines(filePath, lines.GetRange(0, lines.Count - 6).ToArray());
        }
    }
}
