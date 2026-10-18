using System;
using System.Collections.Generic;
using BusinessLogic;
using Ninject;

namespace ConsoleView
{
    /// <summary>
    /// Реализует консольное представление приложения DecanatPRO:
    /// отображает меню и передаёт пользовательские действия
    /// в слой бизнес-логики.
    /// </summary>
    internal class Program
    {
        
        private static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        private static Logic logic = ninjectKernel.Get<Logic>();
        /// <summary>
        /// Запускает главный цикл приложения, отображает меню
        /// и обрабатывает выбранные пользователем команды.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        static void Main(string[] args)
        {
           
            while (true)
            {
                Console.Clear();

                Console.WriteLine("DecanatPRO");
                Console.WriteLine("1. Добавить нового студента");
                Console.WriteLine("2. Удалить студента");
                Console.WriteLine("3. Вывести весь список в таблицу");
                Console.WriteLine("4. Вывести гистограмму: распределение студентов по специальностям");
                Console.WriteLine("0. Выход");

                Console.Write("\nВыберите действие: ");
                string choice = Console.ReadLine();

                Console.Clear();

                if (choice == "1")
                {
                    AddStudentInput();
                }

                else if (choice == "2")
                {
                    DeleteStudentInput();

                }

                else if (choice == "3")
                {
                    ShowTableInput();
                }

                else if (choice == "4")
                {
                    HistogramInput();
                }

                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: выберите один из предложенных пунктов.");
                }

                Console.WriteLine("\nНажмите любую клавишу...");

                Console.ReadKey();
            }
        }
        /// <summary>
        /// Выводит гистограмму распределения студентов по специальностям,
        /// используя данные, полученные из бизнес-логики.
        /// </summary>
        private static void HistogramInput()
        {
            Dictionary<string, int> histogram = logic.ShowHistogram();

            foreach (KeyValuePair<string, int> res in histogram)
            {
                Console.Write($"{res.Key} ");

                for (int i = 0; i < res.Value; i++)
                {
                    Console.Write($"*");
                }

                Console.Write($"{res.Value}");
                Console.WriteLine();
            }
        }
        
        private static void ShowTableInput()
        {
            string[,] table = logic.ShowTableList();
            for (int i = 0; i < table.GetLength(0); i++)
            {
                Console.WriteLine($"{i + 1}. {table[i, 0]} {table[i, 1]} {table[i, 2]}");
            }
        }
        
        private static void DeleteStudentInput()
        {
            string[,] table = logic.ShowTableList();

            if (table.Length == 0)
            {
                Console.WriteLine("Пусто.");
            }
            else
            {
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    Console.WriteLine($"{i + 1}. {table[i, 0]} {table[i, 1]} {table[i, 2]}");
                }
                Console.Write("Введите номер студента для удаления: ");

                if (int.TryParse(Console.ReadLine(), out int studentNumber))
                {
                    try
                    {
                        logic.DeleteStudent(studentNumber);
                        Console.WriteLine("Студент удален.");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("\n" + error.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Некорректное число.");
                }
            }
        }
        
        private static void AddStudentInput()
        {
            Console.Write("Введите ФИО студента: ");
            string name = Console.ReadLine();

            Console.Write("Введите специальность студента: ");
            string speciality = Console.ReadLine();

            Console.Write("Введите группу студента: ");
            string group = Console.ReadLine();

            try
            {
                logic.AddStudent(name, speciality, group);

                Console.WriteLine("\nСтудент успешно добавлен.");
            }
            catch (Exception error)
            {
                Console.WriteLine("\n" + error.Message);
            }
        }
    }
}
