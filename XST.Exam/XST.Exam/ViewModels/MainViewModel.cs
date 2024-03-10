using XST.Model;
using XST.Service.Service.IService;

namespace XST.Exam.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    private ITestModelService TestModelService { get; set; }

    public MainViewModel()
    {

        TestModelService = App.GetService<ITestModelService>();

        //TestModel testModel=new TestModel();
        //testModel.Name= "Test";
        //TestModelService.CreateTest(testModel);
    }
}
