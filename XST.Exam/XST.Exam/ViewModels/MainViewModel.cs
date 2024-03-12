using Microsoft.Extensions.DependencyInjection;

using XST.Model;
using XST.Service.Service.IService;

namespace XST.Exam.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    private ITestModelService TestModelService { get; set; }

    public MainViewModel()
    {

        TestModelService =App.Current.Services.GetService<ITestModelService>();

        TestModel testModel = new TestModel();
        testModel.Name = "Test22";
        TestModelService.CreateTest(testModel);
    }
}
