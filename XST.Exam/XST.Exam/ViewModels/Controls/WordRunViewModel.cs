using CommunityToolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XST.Exam.ViewModels.Page;
using XST.Service.Service.IService;
using CommunityToolkit.Mvvm.Input;
using XST.Exam.Model;
using CommunityToolkit.Mvvm.Messaging;
using XST.Exam.Message;
using XST.Exam.Views.Controls;
using XST.Service.Service;
using XST.Model;
using XST.Exam.Common.WordGenerator;
using Avalonia.Controls;
using SukiUI.Controls;
using Avalonia.Media;
namespace XST.Exam.ViewModels.Controls
{
    public partial class WordRunViewModel : WordViewModel
    {
        /// <summary>
        /// 所有次数
        /// </summary>
        [ObservableProperty]
        private int numberTimes;

        /// <summary>
        /// 当前测试次数
        /// </summary>
        [ObservableProperty]
        private int currentnumberTimes;
        /// <summary>
        /// 视图题
        /// </summary>
        [ObservableProperty]
        private object stackControlContet = null;

        /// <summary>
        /// 当前单词答案
        /// </summary>
        [ObservableProperty]
        private string currentWordAnswer = "";
        /// <summary>
        /// 当前含义
        /// </summary>
        [ObservableProperty]
        private string currentMeaning = "请输入答案：";

        [ObservableProperty]
        private SolidColorBrush userAnswerFontColor=new SolidColorBrush(Colors.Black);
        /// <summary>
        /// 输入答案
        /// </summary>
        private string _userAnswer="";
        public string UserAnswer
        {
            get => _userAnswer;
            set
            {
                if (SetProperty(ref _userAnswer, value)) // 设置属性值并检查是否有改变
                {
                    // 如果属性值发生改变，则执行颜色逻辑处理
                    CheckAnswer(_userAnswer);


                }
            }
        }
        private readonly IBaseBaseExamWordService _baseBaseExamWordService;

        private List<BaseExamWord> _runExamWordsList = new List<BaseExamWord>();


        public WordRunViewModel(IBaseBaseExamWordService baseBaseExamWordService)
        {
            _baseBaseExamWordService = baseBaseExamWordService;
            var _examWordsResponse = _baseBaseExamWordService.GetAllBaseExamWords();
            if (_examWordsResponse.Success)
            {
                NumberTimes = WordConfig.NumberTimes;
                CurrentnumberTimes = 1;
                Random random = new Random();
                int n = _examWordsResponse.Data.Count;
                //筛选去重
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    BaseExamWord value = _examWordsResponse.Data[k];
                    _examWordsResponse.Data[k] = _examWordsResponse.Data[n];
                    _examWordsResponse.Data[n] = value;
                }

                _runExamWordsList = _examWordsResponse.Data.Take(NumberTimes).ToList();

                if (_runExamWordsList.Count > 0)
                {
                    if (_runExamWordsList.Count < NumberTimes)
                    {
                        NumberTimes = _runExamWordsList.Count;
                    }
                    WordGenerator();
                }
            }
            else
            {
                NumberTimes = 0;
                Exit();

                SukiHost.ShowDialog("(*/ω＼*)没有单词数据",true,true);
              //  SukiHost.ShowToast("提示", "(*/ω＼*)没有单词数据", TimeSpan.FromSeconds(5), () => Console.WriteLine("Toast clicked !"));
            }
        }
        /// <summary>
        /// 检查是否和答案一致
        /// </summary>
        /// <param name="thisUserAnswer"></param>
        public void CheckAnswer(string thisUserAnswer) 
        {
            if (thisUserAnswer.ToLower() == CurrentWordAnswer.ToLower())
            {
                UserAnswerFontColor = new SolidColorBrush(Colors.Green);
            }
            else
            {
                UserAnswerFontColor = new SolidColorBrush(Colors.Black);
            }
        
        }
        /// <summary>
        /// 生成单词规则器
        /// </summary>
        private void WordGenerator()
        {
            UserAnswerFontColor = new SolidColorBrush(Colors.Black);
            ITrainingGenerator _trainingGenerator = TrainingGeneratorFactory.GetRandomGenerator(1, 2);
            var result = _trainingGenerator.GenerateTrainingPanel(_runExamWordsList[CurrentnumberTimes - 1].Term, _runExamWordsList[CurrentnumberTimes - 1].Definition);
            StackControlContet = result.Item1;
            CurrentWordAnswer = result.Item2;
            CurrentMeaning = result.Item3;
        }

        /// <summary>
        /// 下一个提示词
        /// </summary>
        [RelayCommand]
        public void Go()
        {
            if (CurrentnumberTimes >= NumberTimes)
            {
                Exit();
            }
            else
            {
                if (UserAnswer.ToLower() == currentWordAnswer.ToLower())
                {
                    CurrentnumberTimes++;
                    WordGenerator();
                    UserAnswer = "";
                }
                else
                {
                    SukiHost.ShowToast("提示", "(*/ω＼*)你填错了", TimeSpan.FromSeconds(5), () => Console.WriteLine("Toast clicked !"));
                }
            }
        }
      
    }
}
