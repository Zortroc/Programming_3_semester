using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public delegate void AddDataDelegate(IEnumerable<object> data);
    public delegate void DeleteDataDelegate(int index);
    public interface IView
    {
        event AddDataDelegate AddDataEvent;
        event DeleteDataDelegate DeleteDataEvent;

        void RedrawForm(IEnumerable<IEnumerable<object>> data);
    }
}
