using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XST.Exam.Message;
using XST.Exam.Model;
using XST.Exam.ViewModels.Page;
using XST.Exam.Views.Controls;
using XST.Service.Service.IService;

namespace XST.Exam.ViewModels.Controls
{
    public partial class WordStartViewModel : WordViewModel
    {
        public WordStartViewModel()
        {

        }
        [RelayCommand]
        private void Go()
        {
            ClearRecords();
            //WordConfig.NumberTimes = 5;
            WeakReferenceMessenger.Default.Send(new WordTrainMessage(new WordRun()));
            WeakReferenceMessenger.Default.Send(new LockMenuMessage(false));
          

        }
        [RelayCommand]
        private void GoSetting()
        {
            WeakReferenceMessenger.Default.Send(new WordTrainMessage(new WordSetting()));
        }
        [RelayCommand]
        private void GoWordAdd() 
        {
            WeakReferenceMessenger.Default.Send(new WordTrainMessage(new WordAdd()));

        }
    }
}
