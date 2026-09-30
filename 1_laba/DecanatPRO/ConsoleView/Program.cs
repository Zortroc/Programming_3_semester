using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace ConsoleView
{
    internal class Program
    {
        // создаём объект бизнес-логики, в конструкторе Logic уже добавлены три текстовых студента
        static Logic logic = new Logic();
        static void Main(string[] args)
        {
            while (true)
            {
                // очищаем экран перед новым меню
                Console.Clear();

                Console.WriteLine("DecanatPRO");
                Console.WriteLine("1. Добавить нового студента");
                Console.WriteLine("2. Удалить студента");
                Console.WriteLine("3. Вывести весь список в таблицу");
                Console.WriteLine("4. Вывести гистограмму: распределение студентов по специальностям");
                Console.WriteLine("0. Выход");

                Console.WriteLine("\nВыберите действие: ");
                string choice = Console.ReadLine();

                // очищаем консоль, чтобы результат был на новом экране 
                Console.Clear();

                if (choice == "1") 
                {
                    Console.WriteLine("Добавление нового студента...\n");

                    Console.Write("Введите ФИО студента: ");
                    string name = Console.ReadLine();

                    Console.Write("Введите специальность студента: ");
                    string speciality = Console.ReadLine();

                    Console.Write("Введите группу студента: ");
                    string group = Console.ReadLine();

                    // проверки находятся в Logic.AddStudent(), поэтому ловим возможную ошибку
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

                else if (choice == "2") 
                {
                    // создаём пустой список, Logic заполнит его данными студентов
                    List<string[]> tableList = new List<string[]>();

                    logic.ShowTableList(tableList);
                    
                    if (tableList.Count == 0)
                    {
                        Console.WriteLine("Удаление невозможно: список студентов пуст.");
                    }
                    else
                    {
                        Console.WriteLine("Выберите студента для удаления (0 - отмена):\n");

                        Console.WriteLine(
                            "{0,-4} {1,-30} {2,-30} {3,-15}",
                            "№",
                            "ФИО",
                            "Специальность",
                            "Группа");

                        // выводим список с номерами
                        for (int i = 0; i < tableList.Count; i++)
                        {
                            Console.WriteLine(
                                "{0,-4} {1,-30} {2,-30} {3,-15}",
                                i + 1,
                                tableList[i][0],
                                tableList[i][1],
                                tableList[i][2]);
                        }

                        int studentNumber;

                        // пока пользователь не введёт корректный номер - запрашиваем повторно
                        while (true)
                        {
                            Console.Write("\nВведите номер студента для удаления: ");

                            string input = Console.ReadLine();

                            if (input == null)
                            {
                                // ввод завершился: не продолжаем бесконечно запрашивать номер
                                return;
                            }

                            if (!int.TryParse(input, out studentNumber))
                            {
                                Console.WriteLine("Ошибка: введите число");
                                continue;
                            }

                            if (studentNumber == 0)
                            {
                                break;
                            }

                            if (studentNumber < 1 || studentNumber > tableList.Count)
                            {
                                Console.WriteLine("Ошибка: такого номера нет в списке");
                                continue;
                            }

                            break;
                        }

                        if (studentNumber != 0)
                        {
                            // номер пользователя начинается с 1, индекс списка начинается с 0
                            string[] selectedStudent = tableList[studentNumber - 1];

                            try
                            {
                                // передаём данные выбранного студента в BusinessLogic
                                logic.DeleteStudent(
                                    selectedStudent[0],
                                    selectedStudent[1],
                                    selectedStudent[2]);

                                Console.WriteLine("\nСтудент успешно удалён.");
                            }

                            catch (Exception error)
                            {
                                Console.WriteLine("\n" + error.Message);
                            }
                        }
                    }
                }

                else if (choice == "3")
                {
                    List<string[]> tableList = new List<string[]>();    

                    logic.ShowTableList(tableList);

                    Console.WriteLine("Список всех студентов...\n");

                    if (tableList.Count == 0)
                    {
                        Console.WriteLine("Список студентов пуст.");
                    }
                    else
                    {
                        Console.WriteLine(
                            "{0,-4} {1,-30} {2,-30} {3,-15}",
                            "№",
                            "ФИО",
                            "Специальность",
                            "Группа");

                        for (int i = 0; i < tableList.Count; i++)
                        {
                            Console.WriteLine(
                                "{0, -4} {1, -30} {2, -30} {3, -15}",
                                i + 1,
                                tableList[i][0],
                                tableList[i][1],
                                tableList[i][2]);
                        }
                    }
                }

                else if (choice == "4")
                {
                    // x - названия специальностей
                    List<string> specialities = new List<string>();

                    // y - количество студентов для соответствующей специальности
                    List<int> counts = new List<int>();

                    // Logic заполняет оба списка
                    logic.ShowHistogram(
                        specialities,
                        counts);

                    Console.WriteLine("Распределение студентов по специальностям...\n");

                    if (specialities.Count == 0)
                    {
                        Console.WriteLine("Невозможно построить гистограмму, список студентов пуст.");
                    }
                    else
                    {
                        for (int i = 0; i < specialities.Count; i++)
                        {
                            // создаём строку из звёздочек, если count = 3, получится "***"
                            string stars = new string('*', counts[i]);

                            Console.WriteLine(
                                specialities[i] + 
                                ": " + 
                                stars + 
                                " " + 
                                counts[i]);
                        }
                    }
                }

                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Выберите один из предложенных пунктов.");
                }

                // после выполнения действия прога не сразу вернется в меню, поэтому требуем инпута от пользователя
                Console.WriteLine("\nНажмите любую клавишу...");

                Console.ReadKey();
            }
        }
    }
}
