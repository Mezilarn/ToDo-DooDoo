using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDoDooDoo.services
{
    internal static class UserInputHandler
    {
        public static int GetTaskNumber(DateTime date)
        {
            TodoService.List(date);
            Console.Write("Введите номер задачи: ");
            string input = Console.ReadLine();

            if (Int32.TryParse(input, out int number) && number > 0)
            {
                return number;
            }

            return -1;
        }
    }
}
