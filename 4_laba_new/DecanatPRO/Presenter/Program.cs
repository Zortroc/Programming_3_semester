using Model;
using System.Windows.Forms;
using View;

namespace Presenter
{
    /// <summary>
    /// Содержит точку входа приложения и выполняет запуск Presenter
    /// с моделью студентов и графическим представлением.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Создаёт представление и модель студентов, инициализирует Presenter
        /// и запускает графическое приложение.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        static void Main(string[] args)
        {
            StudentView view = new StudentView();

            new StudentPresenter(view, new StudentModel());

            Application.Run(view);

        }
    }
}