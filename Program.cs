using System;
using System.IO;

namespace AntiProcrastinator
{
    class Program
    {
        static void Main(string[] args)
        {
            const String FilePath = @"C:\Windows\System32\drivers\etc\hosts";

            Console.WriteLine("Let's get to work.");

            StartWebsiteBlocker(FilePath);
        }

        static void StartWebsiteBlocker(String FilePath)
        {
            Console.WriteLine("blocking...");

            StreamWriter sw = new StreamWriter(FilePath, true);
            String website = "\n 127.0.0.0 www.solitaired.com\n 127.0.0.0 https://www.solitaired.com\n 127.0.0.0 solitaired.com\n 127.0.0.0 https://solitaired.com\n 127.0.0.0 http://solitaired.com\n 127.0.0.0 https://solitaired.com/";
            sw.Write(website);
            sw.Close();
            Console.WriteLine("Website has been blocked");
        }

        static void EndWebsiteBlocker(String FilePath)
        {
            Console.WriteLine("Unblocking...");
            Console.WriteLine(FilePath);
        }
    }
}
