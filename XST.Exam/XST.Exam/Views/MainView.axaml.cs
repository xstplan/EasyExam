
using Microsoft.Extensions.DependencyInjection;

using SukiUI.Controls;

using XST.Exam.ViewModels;
using XST.Exam.ViewModels.Page;

namespace XST.Exam.Views;

public partial class MainView : SukiWindow
{
    public MainView()
    {
        InitializeComponent();
        this.DataContext = App.Current.Services.GetService<MainViewModel>();
    }

    private void Binding(object? sender, Avalonia.Input.KeyEventArgs e)
    {
    }
}
