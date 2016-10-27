using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work
{
    class Table:ISubject
    {
        /// <summary>
        /// Хранит информацию о таблице.
        /// Индексация начинается с 0
        /// </summary>
        protected List<List<object>> data;
        protected int countRow;
        protected int countColumn;
        protected List<updateHandler> updates;

        public delegate void updateHandler();

        public Table()
        {
            data = new List<List<object>>();
            updates = new List<updateHandler> ();
            countRow = 0;
            countColumn = 0;
        }

        public Table(int row, int column):this()
        {
            countRow = row;
            countColumn = column;
            for (int i = 0; i < row; i++)
            {
                data.Add(new List<object>(column));
                for (int j = 0; j < column; j++)
                    data[i].Add(null);
            }
        }

        public int CountColumn
        {
            get
            {
                return countColumn;
            }
        }

        public int CountRow
        {
            get
            {
                return countRow;
            }
        }

        public void Put(int row, int column, object value)
        {
            if (row >= CountRow || row < 0 || column >= countColumn || column < 0)
            {
                throw new IndexOutOfRangeException("Выход за границы таблицы");
            }
            data[row][column] = value;

            Notify();
        }

        /// <summary>
        /// Добавляет пустую строку по указанному индексу
        /// и сдвигает строки в сторону увеличения индексации
        /// </summary>
        public void InsertRow(int rowIndex) 
        {
            if (rowIndex > CountRow || rowIndex < 0)
                throw new IndexOutOfRangeException("Выход за границу таблицы");
            data.Add(new List<object>(CountRow));
            countRow++;
            for (int i = CountRow - 1; i > rowIndex; i--)
            {
                data[i] = data[i - 1];
            }
            data[rowIndex] = new List<object>(CountRow);
            for (int i = 0; i < countColumn; i++)
            {
                data[rowIndex].Add(null);
            }

            Notify();
        }

        /// <summary>
        /// Добавляет пустой столбец по указанному индексу
        /// и сдвигает столбцы в сторону увеличения индексации
        /// </summary>
        public void InsertColumn(int columnIndex)
        {
            if (columnIndex > countColumn || columnIndex < 0)
                throw new IndexOutOfRangeException("Выход за границу таблицы");
            countColumn++;
            for (int i = 0; i < CountRow; i++)
            {
                data[i].Add(null);
                for (int j = CountColumn - 1; j > columnIndex; j--)
                {
                    data[i][j] = data[i][j - 1];
                }
            }
            for (int i = 0; i < CountRow; i++)
            {
                data[i][columnIndex] = null; 
            }

            Notify();
        }

        public object Get(int row, int column) 
        {
            if (row >= CountRow || row < 0 || column >= countColumn || column < 0)
                throw new IndexOutOfRangeException("Выход за границу таблицы");
            return data[row][column];
        }

        override
        public string ToString()
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < CountRow; i++)
            {
                for (int j = 0; j < CountColumn; j++)
                {
                    if (data[i][j] != null)
                        res.Append(data[i][j]);
                    else
                        res.Append("NULL");
                    res.Append(' ');
                }
                res.Append('\n');
            }
            return res.ToString();
        }

        public void Attach(IObserver ob)
        {
            updates.Add(ob.Update);
        }

        public void Detach(IObserver ob)
        {
            updates.Remove(ob.Update);
        }

        public void Notify()
        {
            foreach (var update in updates)
            {
                update(this);
            }
        }
    }
}
