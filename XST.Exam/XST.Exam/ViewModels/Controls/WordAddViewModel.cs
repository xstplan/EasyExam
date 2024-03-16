using CommunityToolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.ViewModels.Controls
{
    public partial class WordAddViewModel : WordViewModel
    {
        [ObservableProperty]
        private string text = "1";
    }
}
