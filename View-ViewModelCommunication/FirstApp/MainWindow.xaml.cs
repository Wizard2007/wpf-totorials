using System.Windows;
using FirstApp.ViewModel;

namespace FirstApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e) => StudentViewControl.DataContext = new StudentViewModel();
    }
}
