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
using System.Threading;

namespace bluetooth_remote_1._0
{
    public partial class Form1 : Form
    {
        public SerialPort mySerialPort;
        public int minute;
        public int second;
        static System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
        public Form1()    
        {
            InitializeComponent();
            init_serialPort();
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            l_status.Text = " Not Connected";
            iniTimer();
            
            if (connect() == true)
            {
                l_status.Text = "connected";
            }
            else
            {
                l_status.Text = "not connected";
            }
            
        }
        public void iniTimer()
        {
            aTimer.Interval = (5 * 1000); // 45 mins
            aTimer.Tick += new EventHandler(checkConnection);
        }

        public void resetTimer()
        {
          /*  if (aTimer.Enabled) {
                addItem("timer ok");
            }
            */
            aTimer.Stop();
            aTimer.Start();
           // addItem("Reset");
        }
        public void disconnect()
        {
            mySerialPort.Close();
            l_status.Text = "disconnect";
        }

        private void checkConnection(object sender, EventArgs e)
        {
            
            addItem("Timeout");
            disconnect();
            if (connect() == true)
            {
                l_status.Text = "connected";
            }
            else
            {
                l_status.Text = "not connected";
            }



        }
        // the Serial Port detection routine 
        
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
            aTimer.Stop();
            
            try
            {
                    mySerialPort.Open();
                aTimer.Start();
                return true;
            }
            catch (System.IO.IOException e)
            {
                addItem("No Device Found");
                aTimer.Start();
                return false;
            }
            

            // mySerialPort.Close();
        }
        /*
        private void connect_thread(object obj)
        {
            aTimer.Start();

            try
            {
                mySerialPort.Open();
             //   return true;
            }
            catch (System.IO.IOException e)
            {
                addItem("No Device Found");
           //     return false;
            }
        }
        */
        public void addItem(String text)
        {
           // this.Invoke((MethodInvoker)(() => lb_log.Items.Insert(0, text)));
        }

        private void DataReceivedHandler(
                       object sender,
                       SerialDataReceivedEventArgs e)
        {
            char input;
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            input = Convert.ToChar(indata[0]);
            this.Invoke((MethodInvoker)(() => resetTimer()));
            switch (input)
            {
                case 'a':
                    addItem(indata);
                    Controller.VolumeDown();
                    break;
                case 'b':
                    addItem(indata);
                    Controller.VolumeUp();
                    break;
                case 'c':
                    addItem(indata);
                    Controller.PreviousTrack();
                    break;
                case 'd':
                    addItem(indata);
                    Controller.PlayPause();
                    break;
                case 'e':
                    addItem(indata);
                    Controller.NextTrack();
                    break;
                case 'l':
                    addItem(indata);
                    break;
                case 'x':
                    //addItem(indata);
                    this.Invoke((MethodInvoker)(() => resetTimer()));
                    break;
                case 'r':
                    addItem(indata);
                    break;
                default:
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
                /*
                Thread t = new Thread(new ParameterizedThreadStart(connect_thread));
                t.Start();
                Thread.Sleep(5000); // wait and trink a tee for 500 ms
                t.Abort();

            */
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
            // resetTimer();
        }
    }
}
