using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array Compare has started!\r\n");

            string location = @"D:\CRM\Data_Imports_Exports\Mailbox to compare\";

            List<string> fileCompare = new List<string>();

            List<string> fileToCompare = new List<string>();

            string[] fileContent = Directory.GetFiles(location, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (string file in fileContent)
            {
                if (!file.Contains("Compare"))
                {
                    foreach (string line in File.ReadLines(file))
                    {
                        fileCompare.Add(line);
                    }
                } else if (file.Contains("Compare"))
                {
                    foreach (string lines in File.ReadLines(file))
                    {
                        fileToCompare.Add(lines);
                    }
                }
            }

            string[] result = fileCompare.Intersect(fileToCompare).ToArray();

            foreach (string item in result)
            {
                Console.WriteLine("Aceste sunt diferentele:\n" + item.ToString());
            }

            //if (fileCompare != fileToCompare)
            //{
            //    Console.WriteLine("Continutul din primul fisier, este diferit");
            //}

            Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Fisierele au fost comparate cu succes!");
        }
    }
}
