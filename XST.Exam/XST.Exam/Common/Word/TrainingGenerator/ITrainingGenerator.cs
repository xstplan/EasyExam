using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XST.Model;

namespace XST.Exam.Common.Word
{
    public interface ITrainingGenerator 
    {
        /// <summary>
        /// 生成器接口
        /// </summary>
        /// <param name="problem">问题：答案</param>
        /// <param name="meaning">含义或说明</param>
        /// <returns>
        /// 返回一个Tuple对象，该对象包含以下内容：
        /// Item1: 一个StackPanel，用于显示单词和含义的相关信息或布局。
        /// Item2: 单词的字符串表示或提示。
        /// Item3: 单词含义的字符串表示。
        /// Item4: 整数值，难度。
        /// Item5: 类型。
        /// </returns>
        Tuple<StackPanel, string, string,int> GenerateTrainingPanel(string problem, string meaning);
    }
}
