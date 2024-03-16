using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using XST.Exam.ViewModels.Controls;

namespace XST.Exam.Views.Controls
{
    public partial class WordAdd : UserControl
    {
        public WordAdd()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<WordAddViewModel>();
        }
    }
}
