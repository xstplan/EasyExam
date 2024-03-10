using Avalonia.Controls;

namespace XST.Exam.Views.Page
{
    public partial class WordTrain : UserControl
    {
        public WordTrain()
        {
            InitializeComponent();
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Get<ContentControl>("StackSettings").Content=new AddWord();
        }
    }
}
