using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Commons.Music.Midi;
using System.Runtime.InteropServices;

namespace iSMIDIButtonMapperWinFormsDOTNET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        public const int VK_F1 = 0x70;
        public const int VK_F2 = 0x71;
        public const int VK_F3 = 0x72;
        public const int VK_F4 = 0x73;
        public const int VK_F5 = 0x74;
        public const int VK_F6 = 0x75;
        public const int VK_F7 = 0x76;
        public const int VK_F8 = 0x77;
        public const int VK_F9 = 0x78;
        public const int VK_F10 = 0x79;
        public const int VK_F11 = 0x7A;
        public const int VK_F12 = 0x7B;
        public const int VK_F13 = 0x7C;
        public const int VK_F14 = 0x7D;
        public const int VK_F15 = 0x7E;
        public const int VK_F16 = 0x7F;
        public const int VK_F17 = 0x80;
        public const int VK_F18 = 0x81;
        public const int VK_F19 = 0x82;
        public const int VK_F20 = 0x83;
        public const int VK_F21 = 0x84;
        public const int VK_F22 = 0x85;
        public const int VK_F23 = 0x86;
        public const int VK_F24 = 0x87;

        private void InitialiseMIDI()
        {

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
            noteToKeyboardMap.Add(60, new KeyboardEvent((ushort)VK_F18, 0));
            noteToKeyboardMap.Add(61, new KeyboardEvent((ushort)VK_F19, 0));
            noteToKeyboardMap.Add(62, new KeyboardEvent((ushort)VK_F20, 0));

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

                        Invoke((MethodInvoker)delegate
                        {
                            if (midiKey == 60)
                            {
                                this.button1.Select();
                            }
                            else if (midiKey == 61)
                            {
                                this.button2.Select();
                            }
                            else if (midiKey == 62)
                            {
                                this.button3.Select();
                            }
                        }); 
                    }
                    else
                    {
                        // Simulate a key release event
                        keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);

                    }

                }

            };

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            InitialiseMIDI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var access = MidiAccessManager.Default;
            var iport = access.Outputs.FirstOrDefault(i => i.Id == "Arduino Leonardo") ?? access.Outputs.Last();
            var output = access.OpenOutputAsync(iport.Id).Result;
            output.Send(new byte[] { MidiEvent.NoteOn, 60, 0x70 }, 0, 3, 0);
            output.CloseAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var access = MidiAccessManager.Default;
            var iport = access.Outputs.FirstOrDefault(i => i.Id == "Arduino Leonardo") ?? access.Outputs.Last();
            var output = access.OpenOutputAsync(iport.Id).Result;
            output.Send(new byte[] { MidiEvent.NoteOn, 61, 0x70 }, 0, 3, 0);
            output.CloseAsync();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var access = MidiAccessManager.Default;
            var iport = access.Outputs.FirstOrDefault(i => i.Id == "Arduino Leonardo") ?? access.Outputs.Last();
            var output = access.OpenOutputAsync(iport.Id).Result;
            output.Send(new byte[] { MidiEvent.NoteOn, 62, 0x70 }, 0, 3, 0);
            output.CloseAsync();

        }
    }
}
