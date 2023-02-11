using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //В задании не требовалось указать путь к файлу Students.dat, но можно как и в предыдущих проектах связать это решение с InactiveFolderDeletion и воспользоваться классом PathChecker. Либо вынести этот класс PathChecker в уже созданную библиотеку, но это я оставлю на todo.
            string path = "C:/Users/wired/Desktop/Students.dat";
            string newStudentPath = "C:/Users/wired/Desktop/Students";
            Student[] students = ReadStudents(path);

            //Создадим папку Students
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(newStudentPath);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Создаю словарь, в котором ключом является номер группы, а значение - лист студентов, которые находятся в этой группе
            Dictionary<string, List<Student>> studentList = new Dictionary<string, List<Student>>();
            foreach (Student student in students)
            {
                if (!studentList.ContainsKey(student.Group))
                {
                    studentList[student.Group] = new List<Student>();
                }
                studentList[student.Group].Add(student);
            }

            //Проходимся по словарю и создаем текстовый файл для каждой группы
            foreach (var group in studentList)
            {
                string groupName = group.Key;
                List<Student> groupStudents = group.Value;

                string filePath = newStudentPath +"/"+"группа " + groupName + ".txt";
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (Student student in groupStudents)
                    {
                        sw.WriteLine("Имя: " + student.Name + " " + "Дата рождения: " + student.DateOfBirth.ToString("D"));
                    }
                }
            }
        }

        static Student[] ReadStudents(string dataFile)
        {
            BinaryFormatter formatter= new BinaryFormatter();
            if (File.Exists(dataFile))
            {
                using (var fs = new FileStream(dataFile, FileMode.OpenOrCreate))
                {
                    Student[] Students = (Student[])formatter.Deserialize(fs);
                    foreach (var student in Students) 
                    {
                    Console.WriteLine(student.Name + " " + student.DateOfBirth + " " + student.Group);
                    }
                    return Students;
                }
            }
            else
            {
                throw new Exception("Файл не существует по заданному пути");
            }
        }
    }
}
