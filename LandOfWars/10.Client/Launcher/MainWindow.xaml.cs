using System;
using System.Diagnostics;
using System.Windows;

namespace Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "ZeroEye.exe";
            p.StartInfo.Arguments = "pai";
            p.Start();
            Environment.Exit(1);
        }
    }
}