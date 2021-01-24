using AppKit;
using Foundation;
using Commons.Music.Midi;
using System;
using System.Linq;
using CoreGraphics;

namespace iSMIDIButtonMapper
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
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
            var iport = access.Inputs.FirstOrDefault(i => i.Id == "Arduino Leonardo") ?? access.Inputs.Last();
            var input = access.OpenInputAsync(iport.Id).Result;
            Console.WriteLine("Using " + iport.Id);
            input.MessageReceived += (obj, e) => {
                Console.WriteLine($"{e.Timestamp} {e.Start} {e.Length} {e.Data[0].ToString("X")}");


                InvokeOnMainThread(() => // Need to run the keyboard interaction code on the main thread
                {
                    using (var eventSource = new CGEventSource(CGEventSourceStateID.CombinedSession))
                    {
                        var key = (ushort)NSKey.F12;
                        if (e.Data[0] == 0x90)
                        {
                            var keyDownEvent = new CGEvent(eventSource, key, true);
                            keyDownEvent.Flags = CGEventFlags.Control | CGEventFlags.Shift | CGEventFlags.Command;
                            CGEvent.Post(keyDownEvent, CGEventTapLocation.AnnotatedSession);

                            var keyUpEvent = new CGEvent(eventSource, key, false);
                            keyUpEvent.Flags = CGEventFlags.Control | CGEventFlags.Shift | CGEventFlags.Command;
                            CGEvent.Post(keyUpEvent, CGEventTapLocation.AnnotatedSession);

                        }
                    };
                });
            };

        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
