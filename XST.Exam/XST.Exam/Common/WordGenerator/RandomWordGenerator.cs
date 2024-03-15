using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Common.WordGenerator
{

    /// <summary>
    /// 随机下划线
    /// </summary>
    public class RandomWordGenerator : ITrainingGenerator
    {
        private static Random random = new Random();
        private const char Underscore = '_';

        /// <summary>
        /// 随机下划线
        /// </summary>
        /// <param name="word"></param>
        /// <param name="meaning"></param>
        /// <returns></returns>
        public Tuple<StackPanel, string, string, int> GenerateTrainingPanel(string word, string meaning)
        {
            string displayWord = GenerateDisplayWord(word);
            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center
            };
      
            meaning = string.Format("请补充\"{0}\" 的英文",meaning );
           var textBlock1 = CreateColoredTextBlock();
            textBlock1.Text = string.Format("单词:");

            var textBlock2 = CreateColoredTextBlock();
            textBlock2.Foreground = new SolidColorBrush(Colors.Red);
            textBlock2.Text = displayWord;

            stackPanel.Children.Add(textBlock1);
            stackPanel.Children.Add(textBlock2);
            return new Tuple<StackPanel, string, string, int>(stackPanel, word, meaning, 1);
        }

        private static TextBlock CreateColoredTextBlock() 
        {
            TextBlock textBlock = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 25,
                FontWeight = FontWeight.Bold,
                Foreground = new SolidColorBrush(Colors.Red)
            };
            return textBlock;
        }
        private string GenerateDisplayWord(string word)
        {
            StringBuilder displayWordBuilder = new StringBuilder(word);

            // 随机选择要替换的字母位置
            int numToReplace = random.Next(1, word.Length);
            for (int i = 0; i < numToReplace; i++)
            {
                int indexToReplace = random.Next(0, word.Length);
                displayWordBuilder[indexToReplace] = Underscore;
            }

            return displayWordBuilder.ToString();
        }
    }
}
