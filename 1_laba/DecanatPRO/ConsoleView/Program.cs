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

                else if (choice == "2") 
                {
                    List<string[]> studentList = new List<string[]>();
                    logic.ShowTableList(studentList);

                    if (studentList.Count == 0) 
                    {
                        Console.WriteLine("Пусто.");
                    }
                    else 
                    {
                        for (int i = 0; i < studentList.Count; i++)
                        {
                            Console.WriteLine($"{i+1}. {studentList[i][0]} {studentList[i][1]} {studentList[i][2]}");
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

                else if (choice == "3")
                {
                    List<string[]> tableList = new List<string[]>();    

                    logic.ShowTableList(tableList);

                    if (tableList.Count == 0)
                    {
                        Console.WriteLine("Список студентов пуст.");
                    }
                    else
                    {
                        for (int i = 0; i < tableList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tableList[i][0]} {tableList[i][1]} {tableList[i][2]}");
                        }
                    }
                }

                else if (choice == "4")
                {
                    List<string> specialities = new List<string>();
                    List<int> counts = new List<int>();

                    logic.ShowHistogram(specialities, counts);

                    if (specialities.Count == 0)
                    {
                        Console.WriteLine("Невозможно построить гистограмму, список студентов пуст.");
                    }
                    else
                    {
                        for (int i = 0; i < specialities.Count; i++)
                        {
                            
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
                    Console.WriteLine("Ошибка: выберите один из предложенных пунктов.");
                }

                Console.WriteLine("\nНажмите любую клавишу...");

                Console.ReadKey();
            }
        }

    }
}
