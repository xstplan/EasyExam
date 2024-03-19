using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using SukiUI.Controls;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XST.Exam.Message;
using XST.Model;
using XST.Service.Service.IService;

namespace XST.Exam.ViewModels.Controls
{
    public partial class WordAddDialogViewModel:ViewModelBase
    {
        [ObservableProperty]
        private string term = "";
        [ObservableProperty]
        private string definition = "";

        [ObservableProperty]
        private string category = "";

        IBaseExamWordService _baseExamWordService1 { get; }
        public WordAddDialogViewModel(IBaseExamWordService baseBaseExamWordService)
        {
            _baseExamWordService1 = baseBaseExamWordService;
        }
        [RelayCommand]
        public void SaveWord()
        {
            BaseExamWord baseExamWord = new BaseExamWord();
            baseExamWord.Term = Term;
            baseExamWord.Definition = Definition;
            baseExamWord.Category = Category;
            baseExamWord.CreatedAt = DateTime.Now;
            _baseExamWordService1.CreateBaseExamWord(baseExamWord);
            CloseDialog();
        }
        [RelayCommand]
        public void CloseDialog()
        {
            WeakReferenceMessenger.Default.Send<WordAddDataMessage>(new WordAddDataMessage(true));
            SukiHost.CloseDialog();
        }

       
    }
}
