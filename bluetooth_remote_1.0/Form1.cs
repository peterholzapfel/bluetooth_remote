using SpotifyControl;
using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bluetooth_remote_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void connect()
        {
            SerialPort serialPort = new SerialPort();
            l_status.Text = "connecting...";
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM4"; // Set in Windows
            serialPort.Open();
            int counter = 0;
            char input;
            while (serialPort.IsOpen)
            {
                l_status.Text = "connected";
                while (serialPort.BytesToRead > 0)
                {
                    input = Convert.ToChar(serialPort.ReadChar());
                    switch (input)
                    {
                        case '1':
                            Controller.VolumeDown();
                            break;
                        case '2':
                            Controller.VolumeUp();
                            break;
                        case '3':
                            Controller.PreviousTrack();
                            break;
                        case '4':
                            Controller.PlayPause();
                            break;
                        case '5':
                            Controller.NextTrack();
                            break;
                    }
                }
            }
            l_status.Text = "disconnected";
        }

        private void b_connect_Click(object sender, EventArgs e)
        {
            connect(); 
        }

        private void l_status_Click(object sender, EventArgs e)
        {

        }

        private void b_disconnect_Click(object sender, EventArgs e)
        {
            l_disconnect.Text = "disconnect";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
