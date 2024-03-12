using Microsoft.Extensions.DependencyInjection;

using XST.Model;
using XST.Service.Service.IService;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using XST.Exam.Message;
using CommunityToolkit.Mvvm.Messaging;
namespace XST.Exam.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool sideMenuIsEnabled = true;

    [ObservableProperty]
    private double sideMenuIsOpacity = 1;
    private ITestModelService TestModelService { get; set; }

    public MainViewModel()
    {
        WeakReferenceMessenger.Default.Register<LockMenuMessage>(this, LockMenu);

        //TestModelService =App.Current.Services.GetService<ITestModelService>();

        //TestModel testModel = new TestModel();
        //testModel.Name = "Test22";
        //TestModelService.CreateTest(testModel);
    }
    private void LockMenu(object recipient, LockMenuMessage message)
    {
        if (message.Value)
        {
            SideMenuIsEnabled = true;
            SideMenuIsOpacity = 1;
        }
        else
        {
            SideMenuIsEnabled = false;
            SideMenuIsOpacity = 0.5;
        }

    }
    [RelayCommand]
    public void Go ()
    { 
    
    }
}
