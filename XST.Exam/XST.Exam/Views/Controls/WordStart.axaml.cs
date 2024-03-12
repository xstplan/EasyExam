using Avalonia.Controls;

using Microsoft.Extensions.DependencyInjection;

using XST.Exam.ViewModels.Controls;
using XST.Exam.ViewModels.Page;

namespace XST.Exam.Views.Controls
{
    public partial class WordStart : UserControl
    {
        public WordStart()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<WordStartViewModel>();
        }
    }
}
