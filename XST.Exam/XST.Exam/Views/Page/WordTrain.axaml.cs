using Avalonia.Controls;

using Microsoft.Extensions.DependencyInjection;

using XST.Exam.ViewModels.Page;
using XST.Exam.Views.Controls;

namespace XST.Exam.Views.Page
{
    public partial class WordTrain : UserControl
    {
        public WordTrain()
        {
            InitializeComponent();

            this.DataContext=App.Current.Services.GetService<WordTrainViewModel>();
           // this.Get<ContentControl>("StackControl").Content = new WordStart();
        }

       
    }
}
