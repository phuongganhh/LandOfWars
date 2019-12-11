using Core.Services;
using PA.Framework;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ZeroEye
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                BasicServiceStarter.Run<ZeroEyes>();
                Environment.Exit(1);
            }).Start();
        }
    }
    
}
