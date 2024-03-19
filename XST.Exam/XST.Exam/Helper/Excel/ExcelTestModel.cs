using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Helper.Excel
{

    /// <summary>
    /// 表格测试类
    /// </summary>
    public class ExcelTestModel
    {

        /// <summary>
        /// 内容
        /// </summary>
        [Column(0)]
        public string Content { get; set; }

        [Column(1)]
        public string ContentName { get; set; }
    }
}
