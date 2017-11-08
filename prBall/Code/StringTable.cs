using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prBall.Code
{
    public class StringTable
    {
        string[,] _table;
        int _currentRow;

        public StringTable (int rowCount, int columnCount)
        {
            _table = new string[rowCount, columnCount];
            _currentRow = 1;
        }

        public void AddHeader(params string[] header)
        {
            for(int i=0;i<header.Length;i++)
            {
                _table[0, i] = header[i];
            }
        }

        public void AddRow(params string[] row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                _table[_currentRow, i] = row[i];
            }

            _currentRow++;
        }

        public string this[int rowIndex, int columnIndex]
        {
            get { return _table[rowIndex, columnIndex]; }
        }

        public int RowCount
        {
            get { return _table.GetLength(0); }
        }

        public int ColumnCount
        {
            get { return _table.GetLength(1); }
        }

    }
}
