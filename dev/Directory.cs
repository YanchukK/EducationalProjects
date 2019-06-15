using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;

namespace Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirName = "C:\\";

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Directories:");
                var dirs = Directory.GetDirectories(dirName);
                Array.Sort(dirs);
                foreach (string s in dirs)
                {
                    var dirInfo = new DirectoryInfo(s);
                    if (!(dirInfo.Attributes.HasFlag(FileAttributes.Hidden)))
                    {
                        Console.WriteLine(dirInfo.Name);
                    }
                }
            }

            //string dirName = "C:\\Program Files";

            //DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            //Console.WriteLine("Название каталога: {0}", dirInfo.Name);
            //Console.WriteLine("Полное название каталога: {0}", dirInfo.FullName);
            //Console.WriteLine("Время создания каталога: {0}", dirInfo.CreationTime);
            //Console.WriteLine("Корневой каталог: {0}", dirInfo.Root);

            Console.WriteLine();

            do
            {
                Console.Write("Select directory: ");
                string dir = Console.ReadLine();

                if (Directory.Exists(dirName + dir))
                {
                    Console.WriteLine("Directories:");
                    string[] dirs = Directory.GetDirectories(dirName + dir);
                    Array.Sort(dirs);
                    foreach (string s in dirs)
                    {
                        Console.WriteLine(s);
                    }
                }
                else
                {
                    break;
                }

            } while (true);
        }
    }
}
