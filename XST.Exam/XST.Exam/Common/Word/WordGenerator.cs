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

        public Tuple<StackPanel, string, string,int> GenerateWord(BaseExamWord  baseExamWords, int CurrentnumberTimes)
        {
                ITrainingGenerator _trainingGenerator = TrainingGeneratorFactory.GetRandomGenerator(1, 3);
                var result = _trainingGenerator.GenerateTrainingPanel(baseExamWords.Term, baseExamWords.Definition);
                return result;
           
        }
    }
}
