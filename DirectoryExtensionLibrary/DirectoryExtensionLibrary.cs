using System;
using System.IO;

namespace DirectoryExtensionLibrary
{
    public static class DirectorySize
    {
        public static void DirSizeWrite(string pathToDir)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo($@"{pathToDir}");
                long dirSize = DirSize(directoryInfo);
                Console.WriteLine($"Размер директории {directoryInfo.Name} равен " + dirSize + " байт");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    

        public static long DirSize(DirectoryInfo directory)
        {
            long size = 0;
            FileInfo[] fileInfos = directory.GetFiles();
            foreach (FileInfo fileInfo in fileInfos)
            {
                size += fileInfo.Length;
            }

            DirectoryInfo[] dirs = directory.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                size += DirSize(dir);
            }
            return size;
        }
    }


}
