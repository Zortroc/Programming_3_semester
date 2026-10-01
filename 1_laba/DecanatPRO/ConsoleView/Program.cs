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
                    Console.WriteLine("Добавление нового студента...\n");

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
                    List<string[]> tableList = new List<string[]>();

                    logic.ShowTableList(tableList);
                    
                    if (tableList.Count == 0)
                    {
                        Console.WriteLine("Удаление невозможно: список студентов пуст.");
                    }
                    else
                    {
                        Console.WriteLine("Список студентов для удаления...\n");

                        PrintStudentsTable(tableList);

                        int studentNumber;

                        
                        while (true)
                        {
                            Console.Write("\nВведите номер студента для удаления (0 - отмена): ");

                            string input = Console.ReadLine();

                            if (input == null)
                            {
                                
                                return;
                            }

                            if (!int.TryParse(input, out studentNumber))
                            {
                                Console.WriteLine("Ошибка: введите число.");
                                continue;
                            }

                            if (studentNumber == 0)
                            {
                                break;
                            }

                            if (studentNumber < 1 || studentNumber > tableList.Count)
                            {
                                Console.WriteLine("Ошибка: такого номера нет в списке.");
                                continue;
                            }

                            break;
                        }

                        if (studentNumber != 0)
                        {
                            
                            string[] selectedStudent = tableList[studentNumber - 1];

                            try
                            {
                                
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
                        PrintStudentsTable(tableList);     
                    }
                }

                else if (choice == "4")
                {
                    
                    List<string> specialities = new List<string>();

                    
                    List<int> counts = new List<int>();

                    
                    logic.ShowHistogram(specialities, counts);

                    Console.WriteLine("Распределение студентов по специальностям...\n");

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

        private static void PrintStudentsTable(List<string[]> tableList)
        {
            Console.WriteLine(
                "{0,-4} {1,-35} {2,-30} {3,-15}", 
                "#", 
                "ФИО", 
                "Специальность", 
                "Группа");

            for (int i = 0; i < tableList.Count; i++)
            {
                Console.WriteLine(
                    "{0,-4} {1,-35} {2,-30} {3,-15}",
                    i + 1,
                    tableList[i][0],
                    tableList[i][1],
                    tableList[i][2]);
            }
        }
    }
}
