// 📝 Study Notes: Delegates

// 1. The Core Concept

//     What is it? A Delegate is a Variable that holds a Memory Address, but instead of pointing to data (like int x = 5), 
//     it points to the start of a Method in RAM.

//     The "Tee Up": It allows you to connect two classes that don't know each other.

// 2. The Architecture (Class A vs. Class B)

//     Class A (The "Stupid" Class):

//         Example: Button, Downloader, Timer.

//         It knows When something happens ("I finished downloading!"), but it has No Idea what to do next.

//         It contains the Delegate Variable (The Slot).

//     Class B (The "Smart" Class):

//         Example: Program, NotificationService.

//         It contains the Actual Logic/Methods (PlaySound, ShowPopup).

//         Class A never sees Class B. It effectively interacts with Class B "blindly" through the delegate.

// 3. The Workflow (Connecting the Wires)

//     The Pointer: When you write downloader.OnComplete = ShowAlert;, you are taking the memory address of ShowAlert (from Class B)
//     and saving it inside the variable in Class A.

//     The Trigger: When Class A runs OnComplete(), it blindly jumps to that memory address and runs the code found there.

using System;
using System.Threading;
namespace Module16_Delegates
{
    public delegate void DownloadHandler(string filename); // Declaring the delegate first
    class Downloader
    {
        public DownloadHandler OnComplete; // Creating an instance of the delegate
        public void Start(string file)
        {
            Console.WriteLine($"Downloading....");
            Thread.Sleep(2000);

            if(OnComplete != null)
            {
                OnComplete(file); //This is the line that runs the methods in AlertSystem class
            }
        }
    }
    class AlertSystem
    {
        public void ShowPopup(string file)
        {
            Console.WriteLine($"POPUP: {file} finished!");
        }
        public void LogToDisk(string file)
        {
            Console.WriteLine($"LOG: saved {file}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Downloader download = new Downloader();
            AlertSystem alert = new AlertSystem();

            // Since class Downloader and AlertSystem have no idea of each other, we are teeing them up using delegate.
            // Yes! we can connect multiple methods to one delegate using +=
            download.OnComplete = alert.ShowPopup;
            download.OnComplete += alert.LogToDisk;

            download.Start("EldenRing.zip");
        }
    }
}