using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace ConsoleView
{
    /// <summary>
    /// Реализует консольное представление приложения DecanatPRO:
    /// отображает меню и передаёт пользовательские действия
    /// в слой бизнес-логики.
    /// </summary>
    internal class Program
    {
        
        private static Logic logic = new Logic();
        /// <summary>
        /// Запускает главный цикл приложения, отображает меню
        /// и обрабатывает выбранные пользователем команды.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
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
                    List<string> fields = new List<string> { "ФИО", "Специальность", "Группа" };
                    List<string> values = new List<string>();

                    foreach (string field in fields)
                    {
                        string input;
                        do
                        {
                            Console.Write($"введите {field}: ");
                            input = Console.ReadLine().Trim();
                            while (input.Contains("  "))
                            {
                                input = input.Replace("  ", " ");
                            }

                            if (string.IsNullOrWhiteSpace(input))
                            {
                                Console.WriteLine($"ошибка: поле [{field}] не может быть пустым.");
                            }
                        }
                        while (string.IsNullOrWhiteSpace(input));

                        values.Add(input);
                    }

                    string newStudent = string.Join(" | ", values);

                    if (logic.ShowTableList().Contains(newStudent))
                    {
                        Console.WriteLine("ошибка: такой студент уже существует.");
                    }
                    else
                    {
                        logic.AddStudent(values[0], values[1], values[2]);
                        Console.WriteLine("студент успешно добавлен.");
                    }
                }
                else if (choice == "2") // под вопросом.
                {
                    break;    //намудрила
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Список всех студентов в таблице:");
                    foreach (string list in logic.ShowTableList())
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
