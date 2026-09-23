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
        static Logic logic = new Logic();
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

                Console.WriteLine("\nВыберите действие: ");
                string choice = Console.ReadLine();

                Console.Clear();

                if (choice == "1")
                {
                    AddStudent();
                }
                else if (choice == "2")
                {
                    DeleteStudent();
                }
                else if (choice == "3")
                {
                    ListAllStudents();
                }
                else if (choice == "4")
                {
                    ShowHistogram();
                }
                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Выберите из один предложенных пунктов!");
                }

                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("Добавление нового студента...");

            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();

            Console.Write("Введите специальность: ");
            string speciality = Console.ReadLine();

            Console.Write("Введите группу: ");
            string group = Console.ReadLine();

            logic.AddStudent(name, speciality, group);

            Console.WriteLine("\nСтудент добавлен");
        }

        static void DeleteStudetn()
        {
            Console.WriteLine("Удалить студента...");
           
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();

            Console.Write("Введите специальность: ");
            string speciality = Console.ReadLine();

            Console.Write("Введите группу: ");
            string group = Console.ReadLine();

            logic.DeleteStudent(name, speciality, group);

            Console.WriteLine("\nСтудент удален);
        }
    }
}
