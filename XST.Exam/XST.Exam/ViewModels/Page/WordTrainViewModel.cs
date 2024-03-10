using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.ViewModels.Page
{
    public partial class WordTrainViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        [RelayCommand]
        private void Go() 
        {
          
        }
    }
}
