using SignalMessenger.Services;
using System.Windows.Controls;
using System.Windows.Input;

namespace SignalMessenger.Views
{

    public partial class HeaderView : UserControl
    {
        private bool IsMaximized;
        public HeaderView()
        {
            InitializeComponent();
        }

        private void MinimizedClick(object sender, MouseButtonEventArgs e) => HeaderToolService.Instance.Minimize();

        private void MaximizedClick(object sender, MouseButtonEventArgs e)
        {
            if(!IsMaximized)
            {
                HeaderToolService.Instance.Maximize();
                IsMaximized = true;
                MaxBorder.Visibility = System.Windows.Visibility.Collapsed;
                NormBorder.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                HeaderToolService.Instance.Normal();
                IsMaximized = false;
                MaxBorder.Visibility = System.Windows.Visibility.Visible;
                NormBorder.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void CloseClick(object sender, MouseButtonEventArgs e) => HeaderToolService.Instance.Close();
    }
}
