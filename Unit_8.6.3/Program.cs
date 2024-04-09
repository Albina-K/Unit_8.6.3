using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Unit_8_6_3
{
    internal class Program
    {
        public static DirectoryInfo dirInfo2;
        public static DirectoryInfo dirInfo;

        static void Main(string[] args)
        {

                   
            string path = @"C:\\User\\Luft\\SkillFactoryNew";
            if (Directory.Exists(path))
            {

                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    Console.WriteLine($"В папке: {path}");

                    Console.WriteLine($"Всего {DirectoryExtinsion.DirSize(dirInfo)} байт");
                    Console.WriteLine($"Освобождено {DirectoryExtinsion.DirSize(dirInfo)} байт");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Произошла ошибка: {e}"); ; ;
                }
            }


            if (Directory.Exists(path))
            {
                try
                {
                    var dirInfo = new DirectoryInfo(path);
                    foreach (DirectoryInfo directoryInfo in dirInfo.GetDirectories())
                    {
                        directoryInfo.Delete(true);
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
                try
                {
                    var dirInfo = new DirectoryInfo(path);
                    foreach (FileInfo fileInfo in dirInfo.GetFiles())
                    {
                            fileInfo.Delete();

                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Папки не существует");
            }

            string path2 = @"C:\\User\\Luft\\SkillFactoryNew";
            try
            {
                DirectoryInfo dirInfo2 = new DirectoryInfo(path2);
                Console.WriteLine($"В папке: {path2}");

                Console.WriteLine($"Всего {DirectoryExtinsion.DirSize(dirInfo2)} байт");
                Console.WriteLine($"Папка {path2} очищена");
               
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e}"); ; ;
            }

        }


    }


   

    public static class DirectoryExtinsion
    {
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dirs = d.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                size += DirSize(dir);
            }
            return size;
        }
    }
}
