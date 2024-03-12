using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using XST.Exam.ViewModels.Controls;

namespace XST.Exam.Views.Controls
{
    public partial class WordEnd : UserControl
    {
        public WordEnd()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<WordEndViewModel>();
        }
    }
}
