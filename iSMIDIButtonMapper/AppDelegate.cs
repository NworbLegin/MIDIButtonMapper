using AppKit;
using Foundation;
using Commons.Music.Midi;
using System;
using System.Linq;
using CoreGraphics;
using System.Collections.Generic;

namespace iSMIDIButtonMapper
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public struct KeyboardEvent
        {
            public KeyboardEvent(ushort iKeyValue, CGEventFlags iModifierKeys)
            {
                keyValue = iKeyValue;
                modifierKeys = iModifierKeys;
            }
            public ushort keyValue;
            public CGEventFlags modifierKeys;
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application

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
            noteToKeyboardMap.Add(60, new KeyboardEvent((ushort)NSKey.F10, CGEventFlags.Control | CGEventFlags.Shift | CGEventFlags.Command));
            noteToKeyboardMap.Add(61, new KeyboardEvent((ushort)NSKey.F11, CGEventFlags.Control | CGEventFlags.Shift | CGEventFlags.Command));
            noteToKeyboardMap.Add(62, new KeyboardEvent((ushort)NSKey.F12, CGEventFlags.Control | CGEventFlags.Shift | CGEventFlags.Command));

            var iport = access.Inputs.FirstOrDefault(i => i.Id == "Arduino Leonardo") ?? access.Inputs.Last();
            var input = access.OpenInputAsync(iport.Id).Result;
            Console.WriteLine("Using " + iport.Id);
            input.MessageReceived += (obj, e) => {
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
                    CGEventFlags mods = noteToKeyboardMap[midiKey].modifierKeys;


                    InvokeOnMainThread(() => // Need to run the keyboard interaction code on the main thread
                    {
                        using (var eventSource = new CGEventSource(CGEventSourceStateID.CombinedSession))
                        {
                            if (noteOn)
                            {
                                var keyDownEvent = new CGEvent(eventSource, key, true);
                                keyDownEvent.Flags = mods;
                                CGEvent.Post(keyDownEvent, CGEventTapLocation.AnnotatedSession);
                            }
                            else
                            {
                                var keyUpEvent = new CGEvent(eventSource, key, false);
                                keyUpEvent.Flags = mods;
                                CGEvent.Post(keyUpEvent, CGEventTapLocation.AnnotatedSession);
                            }
                        };
                    });

                }

            };

        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
