using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shecan_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            this.BtnAction.IsEnabled= false;
            this.BtnAction.Click += BtnAction_Click;

            this.Loaded += MainWindow_Initialized;
            this.MouseDown += MainWindow_MouseDown;
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private async void MainWindow_Initialized(object sender, EventArgs e)
        {
            await Configuration.Load();
            RefreshStatus();

            this.BtnAction.IsEnabled = true;
        }

        void RefreshStatus()
        {
            if (Configuration.Config.IsEnabled)
            {
                this.LabelStatus.Content = "سرویس شکن با موفقیت متصل است. !";
                this.BtnAction.Content = "غیر فعال کردن";
            }
            else
            {
                this.LabelStatus.Content = "شکن فعال نیست.";
                this.BtnAction.Content = "فعال کردن";
            }
        }
        private void BtnAction_Click(object sender, RoutedEventArgs e)
        {
            if (!Configuration.Config.IsEnabled)
            {
                NetworkManager.SetDNS("178.22.122.100", "185.51.200.2");
                Configuration.Config.IsEnabled = true;
            }
            else
            {
                NetworkManager.UnsetDNS();
                Configuration.Config.IsEnabled = false;
            }
            Configuration.Save();
            RefreshStatus();
        }

        private void LabelCopyright_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://jalaljaleh.github.io/");
        }

        private void LabelShecan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://shecan.ir/");
        }

        private void LabelDeveloper_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://github.com/jalaljaleh");
        }
    }
}
