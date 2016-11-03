using System;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace SpotifyControl
{

    public class Controller
    {
        private const int AppCommand = 0x0319;

        private const int CmdPlayPause = 917504;
        private const int CmdPrevious = 786432;
        private const int CmdNext = 720896;
        private const int Cmd_VolumeDown = 589824;
        private const int Cmd_VolumeUp = 655360;


        public static void PlayPause()
        {
            SendCommand(CmdPlayPause);
        }

        public static void PreviousTrack()
        {
            SendCommand(CmdPrevious);
        }

        public static void NextTrack()
        {
            SendCommand(CmdNext);

        }
        public static void VolumeUp()
        {
            SendCommand(Cmd_VolumeUp);

        }
        public static void VolumeDown()
        {
            SendCommand(Cmd_VolumeDown);

        }



        private static void SendCommand(int command)
        {
            User32.SendMessage(FindSpotifyWindow(), AppCommand, IntPtr.Zero, new IntPtr(command));
        }

        private static IntPtr FindSpotifyWindow()
        {
            return User32.FindWindow("SpotifyMainWindow", null);
        }
    }
}