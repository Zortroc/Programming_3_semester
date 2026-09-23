using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace ConsoleView
{

    //ОТСУТСТВУЮТ ADD|DELETE STUDENT METHODS. (НЕДОРАБОТАНО)
    internal class Program
    {
        // создаём один объект Logic, в к-ом хранится список студентов и методы
        static Logic logic = new Logic();
        static void Main(string[] args)
        {
            while (true)
            {
                // прописываем цикл для менюшки
                Console.WriteLine("DecanatPRO");
                Console.WriteLine("1. Добавить нового студента");
                Console.WriteLine("2. Удалить студента");
                Console.WriteLine("3. Вывести весь список в таблицу");
                Console.WriteLine("4. Вывести гистограмму: распределение студентов по специальностям");
                Console.WriteLine("0. Выход");

                Console.WriteLine("\nВыберите действие: ");
                string choice = Console.ReadLine();

                // очищаем консоль, чтобы результат блы на новом экране 
                Console.Clear();

                if (choice == "1") //доработать
                {
                    break;    //намудрила..
                }
                else if (choice == "2") // под вопросом.
                {
                    break;    //намудрила
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Список всех студентов:");
                    foreach (string list in logic.ListAllStudents())
                    {
                        Console.WriteLine(list);
                    }
                }

                else if (choice == "4")
                {
                    Console.WriteLine("Гистограмма");
                    foreach (string list in logic.ShowHistogram())
                    {
                        Console.WriteLine(list);
                    }
                }
                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Выберите один из предложенных пунктов!");
                }

                // после выполнения действия прога не сразу вернется в меню, поэтому требуем инпута от пользователя
                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }
    }
}
