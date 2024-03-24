using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XST.Exam.Model;
using XST.Model;

namespace XST.Exam.Common.Word
{
    public class WordGenerator
    {
        private Random _random;

        public WordGenerator()
        {
            _random = new Random();
        }
        /// <summary>
        /// 生成器
        /// </summary>
        /// <param name="word">单词</param>
        /// <param name="meaning">单词含义</param>
        /// <returns>
        /// 返回一个Tuple对象，该对象包含以下内容：
        /// Item1: 一个StackPanel，用于显示单词和含义的相关信息。
        /// Item2: 单词的字符串表示。
        /// Item3: 单词含义的字符串表示。
        /// Item4: 整数值，难度。
        /// </returns>
        public Tuple<StackPanel, string, string,int> GenerateWord(BaseExamWord  baseExamWords, int CurrentnumberTimes)
        {
                ITrainingGenerator _trainingGenerator = TrainingGeneratorFactory.GetRandomGenerator(1, 3);
                var result = _trainingGenerator.GenerateTrainingPanel(baseExamWords.Term, baseExamWords.Definition);
                return result;
           
        }
    }
}
