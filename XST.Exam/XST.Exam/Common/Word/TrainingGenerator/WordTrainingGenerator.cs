using Avalonia.Controls.Documents;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XST.Exam.Model;
namespace XST.Exam.Common.Word
{

    /// <summary>
    /// 显示全部，写出单词
    /// </summary>
    public class WordTrainingGenerator: ITrainingGenerator
    {
        private static Random random = new Random();

        public Tuple<StackPanel, string, string, int> GenerateTrainingPanel(string word, string meaning)
        {
            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            SolidColorBrush prevColor = null;

            for (int i = 0; i < word.Length; i += WordConfig.WordOffset)
            {
                string group = word.Substring(i, Math.Min(WordConfig.WordOffset, word.Length - i));
                TextBlock textBlock = CreateColoredTextBlock(group, ref prevColor);
                stackPanel.Children.Add(textBlock);
            }

            meaning = string.Format("请写出 \"{0}\" 单词", meaning);
            return new Tuple<StackPanel, string, string, int>(stackPanel, word, meaning, 1);
        }

        private static TextBlock CreateColoredTextBlock(string text, ref SolidColorBrush prevColor)
        {
            TextBlock textBlock = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 25,
                FontWeight = FontWeight.Bold
            };

            SolidColorBrush colorBrush;

            if (prevColor == null || prevColor.Color == Colors.Green)
            {
                colorBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                colorBrush = new SolidColorBrush(Colors.Green);
            }

            for (int j = 0; j < text.Length; j++)
            {
                textBlock.Inlines.Add(new Run(text[j].ToString()) { Foreground = colorBrush });
            }

            prevColor = colorBrush;
            return textBlock;
        }

        //private static SolidColorBrush GetRandomColor()
        //{
        //    // 定义一个颜色数组
        //    Color[] fixedColors = { Colors.Red, Colors.Blue, Colors.Green,  Colors.Black,Colors.RoyalBlue, Colors.Navy };

        //    // 随机选择数组中的一个颜色
        //    Color selectedColor = fixedColors[random.Next(fixedColors.Length)];

        //    // 返回选定的颜色
        //    return new SolidColorBrush(selectedColor);
        //}
    }
}
