using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Common.WordGenerator
{
    public interface ITrainingGenerator
    {
        /// <summary>
        /// 生成器接口
        /// </summary>
        /// <param name="word">单词</param>
        /// <param name="meaning">单词含义</param>
        /// <returns></returns>
        Tuple<StackPanel, string, string,int> GenerateTrainingPanel(string word, string meaning);
    }
}
