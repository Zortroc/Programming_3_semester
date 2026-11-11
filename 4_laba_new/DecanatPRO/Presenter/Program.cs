using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace Presenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentView view = new StudentView();

            new StudentPresenter(view, new StudentModel());

            Application.Run(view);

        }
    }
}
