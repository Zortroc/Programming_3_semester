using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public delegate void DataChangedDelegate(IEnumerable<IEnumerable<object>> newData);
    public interface IModel<T> where T : class
    {
        event DataChangedDelegate DataChanged;
        void Insert(T item);
        void Delete(int index);
    }
}
