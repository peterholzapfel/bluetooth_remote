using SpotifyControl;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bluetooth_remote_1._0
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            /*
            SerialPort serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM4"; // Set in Windows
            serialPort.Open();
            int counter = 0;
            char input;
            while (serialPort.IsOpen)
            {
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
            */



        }
    }
}
