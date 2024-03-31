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
using Avalonia.Controls;
using SukiUI.Controls;
using Avalonia.Media;
using XST.Exam.Common.Word;
namespace XST.Exam.ViewModels.Controls
{
    public partial class WordRunViewModel : WordViewModel
    {
        private readonly WordDataHandler _wordDataHandler;
        private readonly WordGenerator _wordGenerator;
        private readonly IBaseExamWordService _baseBaseExamWordService;

        #region 属性
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
        private SolidColorBrush userAnswerFontColor = new SolidColorBrush(Colors.Black);
        /// <summary>
        /// 输入答案
        /// </summary>
        private string _userAnswer = "";
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
        #endregion
        /// <summary>
        /// 当前选择的单词
        /// </summary>
        private BaseExamWord _currenExamWord = new BaseExamWord();
        private List<BaseExamWord> _runExamWordsList = new List<BaseExamWord>();
        public WordRunViewModel(IBaseExamWordService baseBaseExamWordService, IBaseTrainingRecordsService baseTrainingRecordsService)
        {
            _baseBaseExamWordService = baseBaseExamWordService;
            _wordDataHandler = new WordDataHandler(baseBaseExamWordService, baseTrainingRecordsService);
            _wordGenerator = new WordGenerator();
            LoadWords();
        }
        /// <summary>
        /// 初始化单词
        /// </summary>
        private void LoadWords()
        {
            _runExamWordsList = _wordDataHandler.LoadWords(WordConfig.Category, WordConfig.NumberTimes, WordConfig.AllRandom);

            if (_runExamWordsList.Count == 0)
            {
                Exit();
                SukiHost.ShowDialog("(*/ω＼*)没有单词数据", true, true);
            }
            else
            {
                NumberTimes = WordConfig.NumberTimes;
                if (_runExamWordsList.Count < NumberTimes)
                {
                    NumberTimes = _runExamWordsList.Count;
                }
                CurrentnumberTimes = 1;
                _currenExamWord = _runExamWordsList[CurrentnumberTimes - 1];
                WordGenerator();
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

            var wordData = _wordGenerator.GenerateWord(_currenExamWord, CurrentnumberTimes);
            StackControlContet = wordData.Item1;
            CurrentWordAnswer = wordData.Item2;
            CurrentMeaning = wordData.Item3;

        }

        /// <summary>
        /// 下一个提示词
        /// </summary>
        [RelayCommand]
        public void Go()
        {
                    
                BaseTrainingRecords TrainingRecordsObj = new BaseTrainingRecords()
                {
                    WordID = _currenExamWord.Id,
                    AnswerDateTime = DateTime.Now,
                    AttemptsCount = 0,
                    LastAttemptDateTime = DateTime.Now,
                };
                //判断当前答案是否正确
                if (UserAnswer.ToLower() == currentWordAnswer.ToLower())
                {
                    TrainingRecordsObj.IsCorrect = true;
                    SetRecords(TrainingRecordsObj);
                }
                else
                {
                    TrainingRecordsObj.IsCorrect = false;
                    SetRecords(TrainingRecordsObj);
                    SukiHost.ShowToast("提示", "(*/ω＼*)你填错了", TimeSpan.FromSeconds(5), () => Console.WriteLine("Toast clicked !"));
                }

            if (CurrentnumberTimes >= NumberTimes)
            {
                _wordDataHandler.AddWordsTraningRecords(GetRecords());
                WordEnd();
            }
            else
            {

                NextWord();
            }


        }
        /// <summary>
        /// 下个单词
        /// </summary>
        /// <remarks>_currenExamWord重新赋值，请注意调用顺序</remarks>
        public void NextWord()
        {
            UserAnswer = "";
            CurrentnumberTimes++;
            _currenExamWord = _runExamWordsList[CurrentnumberTimes - 1];
            WordGenerator();
        }

    }
}
