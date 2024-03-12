using Avalonia.Controls;

using Microsoft.Extensions.DependencyInjection;
using XST.Exam.ViewModels.Page;

namespace XST.Exam.Views.Controls
{
    public partial class WordRun : UserControl
    {
        public WordRun()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<AddWordViewModel>();
        }
    }
}
