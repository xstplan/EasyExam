using Avalonia.Controls;

using Microsoft.Extensions.DependencyInjection;
using XST.Exam.ViewModels.Page;

namespace XST.Exam.Views.Page
{
    public partial class AddWord : UserControl
    {
        public AddWord()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<AddWordViewModel>();
        }
    }
}
