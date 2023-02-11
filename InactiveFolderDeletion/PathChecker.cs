using System;
using System.IO;

namespace InactiveFolderDeletion
{
    public static class PathChecker
    {
        /// <summary>
        /// Метод возвращает true, если путь к папке существует и перезапускает себя, если папка не существует/введённый путь неверен.
        /// </summary>
        /// <param name="pathToFolder"></param>
        /// <returns></returns>
        public static bool IsPathExists(out string pathToFolder)
        {

            Console.WriteLine("Введите путь до папки : ");
            string path = Console.ReadLine();
            if (path != null && path != "")
            {
                DirectoryInfo directory = new DirectoryInfo($@"{path}");
                if (directory.Exists)
                {
                    pathToFolder = path;
                    return true;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное имя или папка не существует.");
                    IsPathExists(out pathToFolder);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели неверное имя или папка не существует.");
                IsPathExists(out pathToFolder);
                return false;
            }
        }
    }
}
