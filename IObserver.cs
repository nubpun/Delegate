using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observ
{
    interface IObserver
    {
        void Update(Object sender);
    }
}
