using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSizeCalc
{
    public static class DirectorySize
    {
        public static long DirSize(DirectoryInfo directory)
        {
            long size = 0;
            FileInfo[] fileInfos= directory.GetFiles();
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
