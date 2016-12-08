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
        public SerialPort mySerialPort;
        
        public Form1()
        {
            InitializeComponent();
            init_serialPort();
            Form1.listBox = this.lb_log;
            l_status.Text = " connecting ...";
            /*
            if (connect() == true)
            {
                l_status.Text = "connected";
            }
            else
            {
                l_status.Text = "not connected";
            }

            */
        }

        public void disconnect()
        {

        }
        public void init_serialPort()
        {
            mySerialPort = new SerialPort("COM4");
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        public bool connect()
        {
            if (mySerialPort.IsOpen == false) {
                mySerialPort.Open();
                if (mySerialPort.IsOpen)
                {
                    l_status.Text = "connected";
                    return true;
                }else
                {
                    return false;
                }
            }
            return true;

            // mySerialPort.Close();
        }
        public void addItem(char text)
        {
            lb_log.Items.Add(text);
        }
        private static void DataReceivedHandler(
                       object sender,
                       SerialDataReceivedEventArgs e)
        {
            char input;
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            input = Convert.ToChar(indata);
           // Form1.listBox.Items.Add(indata);
            switch (input)
            {
                case 'a':
                    Controller.VolumeDown();
                    break;
                case 'b':
                    Controller.VolumeUp();
                    break;
                case 'c':
                    Controller.PreviousTrack();
                    break;
                case 'd':
                    Controller.PlayPause();
                    break;
                case 'e':
                    Controller.NextTrack();
                    break;
                case 'h':
                    Controller.NextTrack();
                    break;
                case 'i':
                    Controller.NextTrack();
                    break;
            }
        }

        private static void addItem()
        {
            throw new NotImplementedException();
        }

        private void b_connect_Click(object sender, EventArgs e)
        {
            l_status.Text = " connecting ...";
            if (connect() == true)
            {
                l_status.Text = "connected";
            } else {
                l_status.Text = "not connected";
            }
        }

        private void l_status_Click(object sender, EventArgs e)
        {

        }

        private void b_disconnect_Click(object sender, EventArgs e)
        {
            mySerialPort.Close();
            l_status.Text = "disconnect";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        static System.Windows.Forms.ListBox listBox;
    }
}
