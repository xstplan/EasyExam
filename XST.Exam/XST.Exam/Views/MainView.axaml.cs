
using Microsoft.Extensions.DependencyInjection;

using SukiUI.Controls;
using XST.Exam.Helper;
using XST.Exam.Model;
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

    private void SukiWindow_Closing(object? sender, Avalonia.Controls.WindowClosingEventArgs e)
    {
        IniFileHelper.WriteValue(WordConfig.ConfigPath, "WordConfig", "NumberTimesType", WordConfig.NumberTimesType.ToString());
        IniFileHelper.WriteValue(WordConfig.ConfigPath, "WordConfig", "NumberTimes", WordConfig.NumberTimes.ToString());
        IniFileHelper.WriteValue(WordConfig.ConfigPath, "WordConfig", "WordOffset", WordConfig.WordOffset.ToString());
        IniFileHelper.WriteValue(WordConfig.ConfigPath, "WordConfig", "Category", WordConfig.Category);
        IniFileHelper.WriteValue(WordConfig.ConfigPath, "WordConfig", "Remember", WordConfig.Remember.ToString());

        

    }
}
