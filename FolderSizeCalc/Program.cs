// Я добавил InactiveFolderDeletion в ссылки этого проекта, для того, чтобы второй раз не писать метод, который проверяет путь к папке.
// Но, дойдя до 3 задания понял, что если я в InactiveFolderDeletion создам связь с этим проектом - произойдет цикличная зависимость. Поэтому я решил вынести методы, касающиеся подсчёта директории, в отдельную библиотеку.
using InactiveFolderDeletion;
using System;
using System.IO;
using DirectoryExtensionLibrary;


namespace FolderSizeCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            PathChecker.IsPathExists(out string pathToFolder);
            DirectorySize.DirSizeWrite(pathToFolder);
            Console.Read();
        }
    }
}
