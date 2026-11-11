using System;
using System.Windows.Forms;


namespace View
{
    internal static class Program
    {
        /// <summary>
        /// Запускает форму StudentView напрямую без создания Presenter.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StudentView());
        }
    }
}