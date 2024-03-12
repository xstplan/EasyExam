using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XST.Exam.Message;
using XST.Exam.Views.Controls;
using XST.Model;
using XST.Service.Service;
using XST.Service.Service.IService;

namespace XST.Exam.ViewModels.Page
{
    public partial class WordTrainViewModel : ViewModelBase
    {
        [ObservableProperty]
        private object stackControlContet = null;

        private ITestModelService TestModelService { get; set; }
        public WordTrainViewModel(ITestModelService testModelService)
        {
            TestModelService = testModelService;

            TestModel testModel = new TestModel();
            testModel.Name = "Test4";
            TestModelService.CreateTest(testModel);
            WeakReferenceMessenger.Default.Register<WordTrainMessage>(this, SwitchWordControls);
            StackControlContet = new WordStart();
        }

        private void SwitchWordControls(object recipient, WordTrainMessage message)
        {
            StackControlContet = message.Value as UserControl;

        }
       

        [RelayCommand]
        private void Go()
        {
            StackControlContet = new WordRun();
        }
    }
}
