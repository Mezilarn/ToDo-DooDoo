using ToDoDooDoo.models;
using ToDoDooDoo.services;

namespace ToDoDooDoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;

            while (true)
            {
                Console.WriteLine("""
                Выберите действие:
                1. Добавить задачу
                2. Отметить выполненным
                3. Снять отметку о выполнении
                4. Удалить задачу
                5. Вывести задачи за день
                6. Выйти
                """);

                string userInput = Console.ReadLine();

                if (!Byte.TryParse(userInput, out byte commandNumber) 
                    || commandNumber < 1 
                    || commandNumber > 6)
                {
                    Console.WriteLine("Некорректный ввод!");
                    continue;
                }

                switch (commandNumber)
                {
                    case 1:
                        Console.Write("Введите задачу: ");
                        TodoService.Add(Console.ReadLine());
                        break;

                    case 2:
                        TodoService.Done(UserInputHandler.GetTaskNumber(now));
                        break;

                    case 3:
                        TodoService.Undone(UserInputHandler.GetTaskNumber(now));
                        break;

                    case 4:
                        TodoService.Delete(UserInputHandler.GetTaskNumber(now));
                        break;

                    case 5:
                        Console.Write("Введите дату в формате 'дд-мм-гггг' или оставьте пустой для сегодняшней даты: ");
                        string date = Console.ReadLine();
                        TodoService.List(date.Length == 0 ? DateTime.Now : DateTime.Parse(date));
                        break;

                    case 6:
                        return;
                }
            }
        }
    }
}
