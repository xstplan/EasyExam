using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Common.WordGenerator
{
    /// <summary>
    /// 写单词类
    /// </summary>
    public class WritingWordsGenerator
    {
        private static Random random = new Random();
        public Tuple<StackPanel, string, string, int> GenerateTrainingPanel(string word, string meaning)
        {
            meaning = string.Format("请写出 \"{0}\" 单词", meaning);
            return new Tuple<StackPanel, string, string, int>(null, word, meaning, 1);
        }
    }
}
