using ToDoDooDoo.models;
using ToDoDooDoo.services;

namespace ToDoDooDoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            TodoService.Add("Сделать лабораторную");
            TodoService.Add("Купить сок");
            TodoService.Add("Доделать фичу");
            TodoService.Done(1);
            TodoService.Done(2);
            TodoService.Undone(2);
            TodoService.Delete(0);
            TodoService.List(now);

        }
    }
}
