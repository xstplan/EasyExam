using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Helper
{
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(int index)
        {
            Index = index;
        }
        public int Index { get; set; }
    }
}
