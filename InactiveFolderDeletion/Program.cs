using System;
using System.IO;
using DirectoryExtensionLibrary; //Библиотека, которую я создал для подсчёта размера папок, потому что не хотел писать один и тот же код в разных проектах.

namespace InactiveFolderDeletion
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan time = TimeSpan.FromMinutes(30);
            PathChecker.IsPathExists(out string pathToFolder);

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo($@"{pathToFolder}");
                long startSize = DirectorySize.DirSize(directoryInfo);
                long deletedSize = 0;
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    if (!LastAccessUnder30(time, file))
                    {
                        deletedSize += file.Length;
                        file.Delete();
                    }
                }
                foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                {
                    if (!LastAccessUnder30(time, directory))
                    {
                        deletedSize += DirectorySize.DirSize(directory);
                        directory.Delete(true);
                    }
                }
                Console.WriteLine("Исходный размер папки: " + startSize + " байт");
                Console.WriteLine("Освобождено: " + deletedSize + " байт");
                Console.WriteLine("Текущий размер папки: " + DirectorySize.DirSize(directoryInfo) + " байт");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Метод возвращает true, если в последние time минут в файле происходили изменения. Иначе возвращает false.
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        static bool LastAccessUnder30(TimeSpan timeSpan, FileInfo file)
        {
            if (DateTime.Now - file.LastWriteTime <= timeSpan)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Метод возвращает true, если в последние time минут в папке происходили изменения. Иначе возвращает false.
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="filePath"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        static bool LastAccessUnder30(TimeSpan timeSpan, DirectoryInfo dir)
        {
            if (DateTime.Now - dir.LastWriteTime <= timeSpan)
                return true;
            else
                return false;
        }

    }
    
}
