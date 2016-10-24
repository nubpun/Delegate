using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work
{
    class View : IObserver
    {
        private Table table;
        public View(Table t)
        {
            t.Attach(this);
            table = t;
        }
        public void Update()
        {
            Console.WriteLine(table);
        }
    }
}
