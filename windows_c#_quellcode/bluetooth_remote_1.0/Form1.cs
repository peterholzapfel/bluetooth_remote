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
using System.Timers;

namespace bluetooth_remote_1._0
{
    public partial class Form1 : Form
    {
        public SerialPort mySerialPort;
        public int minute;
        public int second;
        public System.Timers.Timer aTimer;
        public Form1()    
        {
            InitializeComponent();
            init_serialPort();
            l_status.Text = " connecting ...";
            iniTimer();
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
        public void iniTimer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(checkConnection);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
        }

        public void resetTimer()
        {
            aTimer.Stop();
            aTimer.Start();
        }
        public void disconnect()
        {
            mySerialPort.Close();
            l_status.Text = "disconnect";
        }

        private void checkConnection(object source, ElapsedEventArgs e)
        {
            
            addItem('z');
            

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
                mySerialPort.Close();
                mySerialPort.Open();
                if (mySerialPort.IsOpen)
                {
                    l_status.Text = "connected";
                    return true;
                }else
                {
                    l_status.Text = "not connected";
                    return false;
                }
            }
            return true;

            // mySerialPort.Close();
        }
        public void addItem(char text)
        {
            this.Invoke((MethodInvoker)(() => lb_log.Items.Insert(0, text)));
        }

        private void DataReceivedHandler(
                       object sender,
                       SerialDataReceivedEventArgs e)
        {
            char input;
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            input = Convert.ToChar(indata[0]);
            switch (input)
            {
                case 'a':
                    addItem(input);
                    Controller.VolumeDown();
                    break;
                case 'b':
                    addItem(input);
                    Controller.VolumeUp();
                    break;
                case 'c':
                    addItem(input);
                    Controller.PreviousTrack();
                    break;
                case 'd':
                    addItem(input);
                    Controller.PlayPause();
                    break;
                case 'e':
                    addItem(input);
                    Controller.NextTrack();
                    break;
                case 'l':
                    addItem(input);
                    break;
                case 'r':
                    addItem(input);
                    break;
                case 'x':
                    DateTime currentDate = DateTime.Now;
                    minute = currentDate.Minute;
                    second = currentDate.Second;
                    resetTimer();
                    /*
                    atimer.Stop();
                    atimer.Start();
                    */
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
            disconnect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void b_resetTimer_Click(object sender, EventArgs e)
        {
            resetTimer();
        }
    }
}
