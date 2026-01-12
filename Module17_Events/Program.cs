// 📝 Study Notes: Events (The "Secure" Delegate)

// 1. The Core Concept

//     What is it? An Event is a Security Wrapper around a Delegate.

//     The Analogy: Think of the YouTube Subscribe Button.

//         You can Subscribe (+=).

//         You can Unsubscribe (-=).

//         Crucial: You cannot force the YouTuber to release a video (Invoke is banned).

//         Crucial: You cannot delete other subscribers (= null is banned).

// 2. The Architecture (Publisher vs. Subscriber)

//     The Publisher (Class A - "MotionSensor"):

//         Owns the event.

//         Has Full Control: It can Invoke (()), Overwrite (=), or Clear (null) the event internally.

//     The Subscriber (Class B - "SecurityHub"):

//         Listens to the event.

//         Has Restricted Access: It can only use += or -=.

// 3. Threats of using Delegates without events

//     Delegate (Unsafe): public Action OnMove;

//         Risk: External classes can write OnMove = null; and wipe out all existing logic.

//     Event (Safe): public event Action OnMove;

//         Protection: The Compiler creates a "Concrete Wall." External classes get a compiler error if they try to use = or ().

using System;
using System.Threading;
namespace Module17_Events
{
    public delegate void AlarmHandler();
    class MotionSensor
    {
        public event AlarmHandler MotionDetected;
        public void DetectMovement()
        {
            Console.WriteLine("Movement Detected!");
            if(MotionDetected != null)
            {
                MotionDetected();
            }
        }
    }
    class SecurityHub
    {
        public void CallPolice()
        {
            Console.WriteLine("👮 POLICE ON THE WAY!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MotionSensor sensor = new MotionSensor();
            SecurityHub hub = new SecurityHub();

            // ✅ ALLOWED: Subscription using +=
            // We are plugging the Hub into the Sensor
            sensor.MotionDetected += hub.CallPolice;
            Thread.Sleep(2000);
            Console.WriteLine("System Armed!");
            sensor.DetectMovement();

            // ❌ SABOTAGE TEST (Uncommenting these lines causes Error)
            
            // sensor.MotionDetected = null;
            
            // sensor.MotionDetected();
            // ^ Error: "The event 'MotionDetected' can only be invoked from within the class 'MotionSensor'"
        }
    }
}