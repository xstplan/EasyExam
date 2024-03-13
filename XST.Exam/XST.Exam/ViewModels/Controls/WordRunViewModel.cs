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
namespace XST.Exam.ViewModels.Controls
{
    public partial class WordRunViewModel : ViewModelBase
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

        /// <summary>
        /// 输入答案
        /// </summary>
        [ObservableProperty]
        private string userAnswer = "";

        private readonly IBaseBaseExamWordService _baseBaseExamWordService;

        private List<BaseExamWord> _runExamWordsList = new List<BaseExamWord>();

        public WordRunViewModel(IBaseBaseExamWordService baseBaseExamWordService)
        {

            _baseBaseExamWordService = baseBaseExamWordService;
            NumberTimes = WordConfig.NumberTimes;
            CurrentnumberTimes = 1;

            var _examWordsResponse = _baseBaseExamWordService.GetAllBaseExamWords();
            if (_examWordsResponse.Success)
            {
                Random random = new Random();
                int n = _examWordsResponse.Data.Count;
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
                SukiHost.ShowToast("提示", "(*/ω＼*)没有单词数据", TimeSpan.FromSeconds(5), () => Console.WriteLine("Toast clicked !"));

            }
        }
        private void WordGenerator()
        {
            ITrainingGenerator _trainingGenerator = TrainingGeneratorFactory.GetRandomGenerator(1, 1);
            var result = _trainingGenerator.GenerateTrainingPanel(_runExamWordsList[CurrentnumberTimes - 1].Term, _runExamWordsList[CurrentnumberTimes - 1].Definition);
            StackControlContet = result.Item1;
            CurrentWordAnswer = result.Item2;
            CurrentMeaning = result.Item3;
        }
        [RelayCommand]
        public void Go()
        {
            if (CurrentnumberTimes >= NumberTimes)
            {
                WeakReferenceMessenger.Default.Send(new WordTrainMessage(new WordStart()));
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
