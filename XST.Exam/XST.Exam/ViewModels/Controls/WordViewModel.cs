using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XST.Exam.Message;
using XST.Exam.Views.Controls;

namespace XST.Exam.ViewModels.Controls
{
    public partial class WordViewModel: ObservableObject
    {

        [RelayCommand]
        public void Exit()
        {
            WeakReferenceMessenger.Default.Send(new LockMenuMessage(true));
            WeakReferenceMessenger.Default.Send(new WordTrainMessage(new WordStart()));
        }
    }
}
