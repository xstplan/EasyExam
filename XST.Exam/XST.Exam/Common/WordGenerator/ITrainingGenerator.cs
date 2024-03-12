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
        Tuple<StackPanel, string, string,int> GenerateTrainingPanel(string word, string meaning);
    }
}
