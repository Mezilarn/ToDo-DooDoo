using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDooDoo.models
{
    internal class Todo
    {
        public Guid id { get; set; }
        public string text { get; set; }
        public bool completed { get; set; } = false; 
        public DateTime createdAt { get; set; }
        public DateTime? completedAt { get; set; } = null;

        public Todo(string text = "")
        {
            this.id = Guid.NewGuid();
            this.text = text;
            this.createdAt = DateTime.Now;
        }

        public void printTodo(int todoNumber)
        {
            Console.WriteLine(todoNumber + ". " + this.text);
            Console.Write("Выполнено: " + (this.completed ? "Да" : "Нет") + ". ");
            if (this.completed)
            {
                Console.WriteLine("Время выполнения: " + this.completedAt);
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
