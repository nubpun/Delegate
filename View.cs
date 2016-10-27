using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observ
{
    class View : IObserver
    {
        private Table table;
        public View(Table table)
        {
            table.Attach(this);
            this.table = table;
        }
        public void Update(List<List<object>> data)
        {
            Console.WriteLine(table);
        }
    }
}
