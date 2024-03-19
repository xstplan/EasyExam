using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using SukiUI.Controls;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using XST.Exam.Message;
using XST.Exam.Views;
using XST.Exam.Views.Controls;
using XST.Model;
using XST.Service.Service.IService;

namespace XST.Exam.ViewModels.Controls
{
    public partial class WordAddViewModel : WordViewModel
    {


        [ObservableProperty]
        private ObservableCollection<BaseExamWord> examWordList;


        IBaseExamWordService _baseExamWordService1 { get; }
        public WordAddViewModel(IBaseExamWordService baseBaseExamWordService)
        {
          
            _baseExamWordService1 = baseBaseExamWordService;
            InitializeData();
            WeakReferenceMessenger.Default.Register<WordAddDataMessage>(this, InitializeDataMessage);
            //   People = new ObservableCollection<Person>(people);
        }
        private void InitializeDataMessage(object recipient, WordAddDataMessage message)
        {
            InitializeData();

        }
        public void InitializeData()
        {
            var _baseBaseExamWordToResponse = _baseExamWordService1.GetAllBaseExamWords();
            if (_baseBaseExamWordToResponse.Success)
            {
                ExamWordList = new ObservableCollection<BaseExamWord>(_baseBaseExamWordToResponse.Data);
            }
            else
            {
                SukiHost.ShowDialog(_baseBaseExamWordToResponse.Message);
            }
        }
        [RelayCommand]
        public void ShowAddWindow()
        {
            SukiHost.ShowDialog(new WordAddDialog(), allowBackgroundClose: true);

            //SukiHost.CloseDialog();
        }
        [RelayCommand]
        public void DeleleWord(int id)
        {
            _baseExamWordService1.DeleteBaseExamWord(id);
            InitializeData();
        }
    }

}
