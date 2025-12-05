using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoDooDoo.models;

namespace ToDoDooDoo.services
{
    internal static class TodoService
    {
        private static DateTime now = DateTime.Now;

        public static void List(DateTime date)
        {
            List<string> lines = Repository.getDataFile(date);
            if (lines.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }
            int taskNumber = 1;
            foreach (string line in lines)
            {
                string[] info = line.Split(',');
                Todo todo = new Todo();
                todo.id = Guid.Parse(info[0]);
                todo.text = info[1];
                todo.completed = bool.Parse(info[2]);
                todo.createdAt = DateTime.Parse(info[3]);
                if (!string.IsNullOrWhiteSpace(info[4]))
                {
                    todo.completedAt = DateTime.Parse(info[4]);
                }
                todo.printTodo(taskNumber);
                taskNumber++;
            }
        }
        public static void Add(string text)
        {
            if (!Directory.Exists(Repository.dataDirectory))
            {
                Directory.CreateDirectory(Repository.dataDirectory);
            }
            Todo todo = new Todo(text);
            string[] appendLine = { 
                $"{todo.id},{todo.text},{todo.completed},{todo.createdAt},{todo.completedAt}"};
            File.AppendAllLines(Repository.getFilePath(now), appendLine, Encoding.UTF8);

        }
        public static void Done(int todoNumber)
        {
            List<string> lines = Repository.getDataFile(now);
            string[] info = lines[todoNumber].Split(',');
            info[2] = "True";
            lines[todoNumber] = string.Join(',', info);
            File.WriteAllLines(Repository.getFilePath(now), lines, Encoding.UTF8);
        }

        public static void Undone(int todoNumber)
        {
            List<string> lines = Repository.getDataFile(now);
            string[] info = lines[todoNumber].Split(',');
            info[2] = "False";
            lines[todoNumber] = string.Join(',', info);
            File.WriteAllLines(Repository.getFilePath(now), lines, Encoding.UTF8);
        }

        public static void Delete(int todoNumber) 
        {
            List<string> lines = Repository.getDataFile(now);
            if (lines.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }
            lines.RemoveAt(todoNumber);
            File.WriteAllLines(Repository.getFilePath(now), lines, Encoding.UTF8);
        }
    }
}
