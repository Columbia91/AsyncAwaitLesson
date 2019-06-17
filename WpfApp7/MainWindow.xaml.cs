using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ProcessButtonClick(object sender, RoutedEventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;

            var name = nameTextBox.Text;
            if (await SaveToDatabase(name)) // заставляет главный поток уснуть и дождаться результата
            {
                await SendToNet(name);
                MessageBox.Show("Имя успешно обработано");
            }
            progressBar.Visibility = Visibility.Collapsed;
        }
        private Task<bool> SaveToDatabase(string name)
        {
            return Task.FromResult(true);
            //return Task.Run(() =>
            //{

            //    Thread.Sleep(5000);
            //    return true;
            //});
        }
        private Task SendToNet(string name)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
        }
    }
}
