using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XST.Exam.Model;
using XST.Service;
using XST.Service.Service.IService;

namespace XST.Exam.ViewModels.Controls
{


    public partial class WordSettingViewModel : WordViewModel
    {

        #region 设置
        /// <summary>
        /// 练习多少个
        /// </summary>
        /// 
        private int _numberTimes = WordConfig.NumberTimes;
        public int NumberTimes
        {
            get => _numberTimes;
            set
            {
                if (SetProperty(ref _numberTimes, value)) // 设置属性值并检查是否有改变
                {
                    WordConfig.NumberTimes = NumberTimes;
                }
            }
        }
        /// <summary>
        /// 间隔颜色
        /// </summary>
        /// 
        private int _wordOffset = WordConfig.WordOffset;
        public int WordOffset
        {
            get => _wordOffset;
            set
            {
                if (SetProperty(ref _wordOffset, value)) // 设置属性值并检查是否有改变
                {
                    WordConfig.WordOffset = _wordOffset;
                }
            }
        }
        #endregion


        [ObservableProperty]
        private ObservableCollection<WordCategory> wordCategoriesList =new ObservableCollection<WordCategory>() ;
       

        IBaseExamWordService _baseBaseExamWordService1 { get; set; }
        public WordSettingViewModel(IBaseExamWordService baseBaseExamWordService)
        {
            _baseBaseExamWordService1 = baseBaseExamWordService;

            var _examWordsToResponse = _baseBaseExamWordService1.GetAllBaseExamWords();

            if (_examWordsToResponse.Success)
            {
                var distinctCategories = _examWordsToResponse.Data
                  .GroupBy(a => a.Category)
                  .Select(a => a.Key)
                  .Distinct().ToList();

                WordCategoriesList.Add(new WordCategory { IsChecked = false, Name = "全部" });
                foreach (var category in distinctCategories)
                {
                   
                    var wordCategory = new WordCategory
                    {
                        Name = category,
                        IsChecked = category == WordConfig.Category  // 如果与 WordConfig.Category 匹配，则设置为选中状态
                    };
                    WordCategoriesList.Add(wordCategory);
                }

                // 如果有数据并且列表不为空，将第一个项设置为选中状态
                if (WordConfig.Category=="全部")
                {
                    WordCategoriesList[0].IsChecked = true;
                }

            }
        }

    }
    public class WordCategory
    {

        private string _name;
        private bool _isChecked;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    if (value)
                    {
                        WordConfig.Category = Name;
                    }
                    OnPropertyChanged(nameof(IsChecked));

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
