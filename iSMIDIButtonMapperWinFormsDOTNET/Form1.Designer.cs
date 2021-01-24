using Commons.Music.Midi;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace iSMIDIButtonMapperWinFormsDOTNET
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public struct KeyboardEvent
        {
            public KeyboardEvent(ushort iKeyValue, UInt32 iModifierKeys)
            {
                keyValue = iKeyValue;
                modifierKeys = iModifierKeys;
            }
            public ushort keyValue;
            public UInt32 modifierKeys;
        }

        // Import the user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        // Declare some keyboard keys as constants with its respective code
        // See Virtual Code Keys: https://msdn.microsoft.com/en-us/library/dd375731(v=vs.85).aspx
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        public const int VK_RCONTROL = 0xA3; //Right Control key code
        public const int VK_F10 = 0x79;
        public const int VK_F11 = 0x7A;
        public const int VK_F12 = 0x7B;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";


            // Enumerate the MIDI devices available

            var access = MidiAccessManager.Default;
            foreach (var i in access.Inputs)
                Console.WriteLine(i.Id + " : " + i.Name);
            if (!access.Inputs.Any())
            {
                Console.WriteLine("No input device found.");
                return;
            }

            var noteToKeyboardMap = new Dictionary<byte, KeyboardEvent>();
            noteToKeyboardMap.Add(60, new KeyboardEvent((ushort)VK_F10, 0));
            noteToKeyboardMap.Add(61, new KeyboardEvent((ushort)VK_F11, 0));
            noteToKeyboardMap.Add(62, new KeyboardEvent((ushort)VK_F12, 0));

            var iport = access.Inputs.FirstOrDefault(i => i.Id == "Arduino Leonardo") ?? access.Inputs.Last();
            var input = access.OpenInputAsync(iport.Id).Result;
            Console.WriteLine("Using " + iport.Id);
            input.MessageReceived += (obj, e) =>
            {
                Console.WriteLine($"{e.Timestamp} {e.Start} {e.Length} {e.Data[0].ToString("X")}");

                bool noteEvent = false;
                bool noteOn = false;
                byte channel = 0;
                byte midiKey = 0;
                byte velocity = 0;

                // Decode the MIDI packet for note information
                byte startByte = e.Data[0];
                if ((startByte & 0x90) == 0x90)
                {
                    // We have a Note On event
                    noteEvent = true;
                    noteOn = true;

                    // Decode the channel
                    channel = (byte)(startByte & 0x0F);

                    // Decode the key value
                    midiKey = (byte)(e.Data[1] & 0x7F);

                    // Decode the velocity
                    velocity = (byte)(e.Data[2] & 0x7F);
                }
                else if ((startByte & 0x80) == 0x80)
                {
                    // We have a Note Off event
                    noteEvent = true;
                    noteOn = false;

                    // Decode the channel
                    channel = (byte)(startByte & 0x0F);

                    // Decode the key value
                    midiKey = (byte)(e.Data[1] & 0x7F);

                    // Decode the velocity
                    velocity = (byte)(e.Data[2] & 0x7F);
                }

                if (noteEvent == true)
                {
                    // Calculate keyboard event to send based on MIDI key
                    var key = noteToKeyboardMap[midiKey].keyValue;
                    UInt32 mods = noteToKeyboardMap[midiKey].modifierKeys;


                    if (noteOn)
                    {
                        // Simulate a key press event
                        keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY, 0);
                    }
                    else
                    {
                        // Simulate a key release event
                        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);

                    }

                }

            };

        }

        #endregion
    }
}

