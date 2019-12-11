using Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RIP_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Extensions.UpdateStatus();
                Extensions.DrawAuthor();
                Console.Write("URL: ");
                var url = Console.ReadLine();
                Finding.Instance.Find(url);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("GET TEMPLATE SUCCESS!");
                Process.Start(Directory.GetCurrentDirectory());
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Press Enter to Exit");
                Console.ReadLine();
            }
            
        }
    }
}
