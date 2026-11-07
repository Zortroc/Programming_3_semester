using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IModel<T> where T : class
    {
        event Action<IEnumerable<IEnumerable<object>>> DataChanged;

        void Insert(T item);
        void Delete(int index);
        void Refresh();
    }
}
