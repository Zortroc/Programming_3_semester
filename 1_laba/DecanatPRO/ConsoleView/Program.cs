using System;
using System.Collections.Generic;
using BusinessLogic;

namespace ConsoleView
{
    internal class Program
    {
        private static Logic logic = new Logic();
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
            List<string[]> table = logic.ShowTableList();

            int number = 1;
            foreach (string[] field in table)
            {
                Console.WriteLine($"{number}. {field[0]} {field[1]} {field[2]}");
                number++;
            }
        }

        private static void DeleteStudentInput()
        {
            List<string[]> table = logic.ShowTableList();

            if (table.Count == 0)
            {
                Console.WriteLine("Пусто.");
            }
            else
            {
                for (int i = 0; i < table.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {table[i][0]} {table[i][1]} {table[i][2]}");
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
