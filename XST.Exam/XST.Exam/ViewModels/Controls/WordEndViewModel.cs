using Avalonia.Markup.Xaml.Converters;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XST.Exam.ViewModels.Page;
using XST.Model;
using XST.Service.Service.IService;

namespace XST.Exam.ViewModels.Controls
{
    public partial class WordEndViewModel : WordViewModel
    {
        [ObservableProperty]
        public SolidColorBrush star1 = new SolidColorBrush(Avalonia.Media.Color.Parse("#E5E5E5"));
        [ObservableProperty]
        public SolidColorBrush star2 = new SolidColorBrush(Avalonia.Media.Color.Parse("#E5E5E5"));
        [ObservableProperty]
        public SolidColorBrush star3 = new SolidColorBrush(Avalonia.Media.Color.Parse("#E5E5E5"));
      
        /// <summary>
        /// 正确次数
        /// </summary>
        [ObservableProperty]
        public int correctCount=0;
        /// <summary>
        /// 不正确
        /// </summary>
        [ObservableProperty]
        public int incorrectCount=0;

        [ObservableProperty]
        public string tip="";
        public WordEndViewModel()
        {

            GetStarLevel();

        }
        public  void GetStarLevel()
        {
            List<BaseTrainingRecords> recordsList = GetRecords();
            // 统计答题记录中答题正确和错误的数量
            CorrectCount = recordsList.Count(record => record.IsCorrect);
            IncorrectCount = recordsList.Count(record => !record.IsCorrect);

            double percentCorrect = ((double)CorrectCount / recordsList.Count) * 100;
            if (percentCorrect >= 90)
            {
                Star1 = new SolidColorBrush(Avalonia.Media.Color.Parse("#ECBF0B"));
                Star2 = new SolidColorBrush(Avalonia.Media.Color.Parse("#ECBF0B"));
                Star3 = new SolidColorBrush(Avalonia.Media.Color.Parse("#ECBF0B"));
                Tip = "恭喜您，做的很棒！";
             
            }
            else if (percentCorrect >= 60)
            {
                Star1 = new SolidColorBrush(Avalonia.Media.Color.Parse("#ECBF0B"));
                Star2 = new SolidColorBrush(Avalonia.Media.Color.Parse("#ECBF0B"));
                Star3 = new SolidColorBrush(Avalonia.Media.Color.Parse("#E5E5E5"));
                Star3 = new SolidColorBrush(Avalonia.Media.Color.Parse("#E5E5E5"));
                Tip = "还可以，继续加油吧";

            }
            else if(percentCorrect >= 30)
            {
                Star1 = new SolidColorBrush(Avalonia.Media.Color.Parse("#ECBF0B"));
                Star2 = new SolidColorBrush(Avalonia.Media.Color.Parse("#E5E5E5"));
              
                Tip = "错误有点多，继续努力提高吧！";
            }
            else
            {
                Star1 = new SolidColorBrush(Avalonia.Media.Color.Parse("#E5E5E5"));
                Star2 = new SolidColorBrush(Avalonia.Media.Color.Parse("#E5E5E5"));
                Star3 = new SolidColorBrush(Avalonia.Media.Color.Parse("#E5E5E5"));
                Tip = "分数不太行继续努力吧！";
            }
        }
    }
}
