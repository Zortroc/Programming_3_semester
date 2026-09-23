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
                    Console.WriteLine("Выберите один из предложенных пунктов!");
                }

                // после выполнения действия прога не сразу вернется в меню, поэтому требуем инпута от пользователя
                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        // прописываем методы по очереди
        static void AddStudent()
        {
            Console.WriteLine("Добавление нового студента...");

            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();

            Console.Write("Введите специальность: ");
            string speciality = Console.ReadLine();

            Console.Write("Введите группу: ");
            string group = Console.ReadLine();

            // передаем данные в бизнес-логику
            // именно Logic создает объект Student и добавляет его в список students
            logic.AddStudent(name, speciality, group);

            Console.WriteLine("\nСтудент добавлен");
        }

        static void DeleteStudent()
        {
            Console.WriteLine("Удалить студента...");
           
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();

            Console.Write("Введите специальность: ");
            string speciality = Console.ReadLine();

            Console.Write("Введите группу: ");
            string group = Console.ReadLine();

            // снова передаем данные в логику
            // внутри Logic прога находит нужного студента, а затем удаляет его
            logic.DeleteStudent(name, speciality, group);

            Console.WriteLine("\nСтудент удален");
        }

        static void ListAllStudents()
        { // короче тут ошибка, потому что компилятор не видит ссылку на Student,
          // который берется из класса Model, но прикол в том,
          // что нам нельзя делать связь ConsoleView -> Model, поэтому надо подумать что сделать
            List<Student> allStudents = logic.ListAllStudents();
        }

        static void ShowHistogram()
        {
            // вызываем метод ShowHistogram из Logic
            // он возвращает лист, то есть весь список данных для студента
            List<string> histogram = logic.ShowHistogram();

            // если список пустой, значит студентов ещё нет и строить статистику не из чего
            if (histogram.Count == 0)
            {
                Console.WriteLine("Гистограмму невозможно построить, список пуст");
                return;
            }

            Console.WriteLine("Распределение студентов по специальностям...\n");

            // перебираем строки, к-ые вернул Logic
            // например, сначала line = "ИТ: 3",
            // затем line = "Дизайн: 1"
            foreach (string line in histogram)
            {
                Console.WriteLine(line);
            }
        }
    }
}
