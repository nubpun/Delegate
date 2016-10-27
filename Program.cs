using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observ
{
    class Program
    {
        static void Main(string[] args)
        {
            Table t = new Table(3, 3);
            
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    t.Put(i, j, i + j);
                }
            View v = new View(t);
            t.InsertColumn(3);
            t.InsertRow(3);
            t.InsertRow(0);
            t.Detach(v);
            t.InsertRow(0);
            t.Attach(v);
            v.Update(t);
        }
    }
}
