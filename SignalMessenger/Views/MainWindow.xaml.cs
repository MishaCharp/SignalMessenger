using SignalMessenger.Services;
using System.Windows;

namespace SignalMessenger.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HeaderToolService.Instance.OnMinimized += () => this.WindowState = WindowState.Minimized;
            HeaderToolService.Instance.OnMaximized += () => this.WindowState = WindowState.Maximized;
            HeaderToolService.Instance.OnNormal += () => this.WindowState = WindowState.Normal;
            HeaderToolService.Instance.OnClosed += () => Application.Current.Shutdown();
        }

        private void Header_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();
    }
}
