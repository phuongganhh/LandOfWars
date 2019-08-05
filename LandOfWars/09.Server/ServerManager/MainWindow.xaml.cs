using ServerManager.TCP;
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

namespace ServerManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ToggleButton_LoginServer(object sender, MouseButtonEventArgs e)
        {
            var btn = (ToggleButton)sender;
            try
            {
                if (btn.Enable)
                {
                    Login.Instance.Start();
                    this.Mess("Login đã khởi động với Port: 9958");
                }
                else
                {
                    Login.Instance.Stop();
                    this.Mess("Login đã dừng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btn = new ToggleButton();
            }
            
        }
        private void Mess(string m)
        {
            this.Dispatcher.BeginInvoke(new Action(()=> {
                this.rtb.AppendText(m + Environment.NewLine);
            }));
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }

    }
}
