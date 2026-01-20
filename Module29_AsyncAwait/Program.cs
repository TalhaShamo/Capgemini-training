// Study Notes: Async, Await, and Task
// 1. The Problem: Synchronous vs. Asynchronous

// Synchronous (The Old Way): Code runs line-by-line. If one line takes 5 seconds (like downloading a file), the entire 
// application freezes. You cannot click buttons or move the window.

// Asynchronous (The New Way): Long-running operations happen in the background. The application remains responsive (clickable) 
// while the work finishes.
// 2. The Analogy: The Coffee Shop

//     Synchronous: You order. The cashier stops everything, watches the coffee brew for 2 minutes, hands it to you, then serves 
//     the next person.

//     Asynchronous: You order. The cashier gives you a Receipt (Task) and immediately serves the next person. When your coffee is 
//     ready, you use the receipt to pick it up.

// 3. The 3 Key Components

// A. async (The Modifier)

//     Placed in the method signature: public async Task DoWork()

//     The Rule: This keyword enables the use of await inside the method.

//     Warning: If you mark a method async but don't use await inside it, it will run synchronously (just like normal code) 
//     and the compiler will give you a warning.

// B. await (The Pause Button)

//     Function: It yields control back to the caller. It says, "Pause this method until the task is done, but let the rest of the app keep running."

//     Unwrapping: If a task returns data (e.g., Task<int>), await automatically unwraps it to give you the plain int.

// C. Task (The Receipt)

//     Represents an operation in progress.

//     It is the standard return type for async methods.

// 5. Essential Syntax Rules

// a. The Naming Convention Always append Async to the end of your method name.

//     Bad: GetData()

//     Good: GetDataAsync()

// b. The Main Method To use await inside static void Main, you must change the signature to: static async Task Main(string[] args)

// c. Parallel Execution (The "Hot Task") Tasks start running the moment you call the function, not when you await them.

using System;
namespace Module29_AsyncAwait
{
    class Program
    {
        // Simulated fake server request
        static async Task<string> FetchDataAsync(string serverName, int delayTime)
        {
            Console.WriteLine($"Requesting {serverName}");
            
            //Simulating network delay
            await Task.Delay(delayTime);

            Console.WriteLine($"Recieved data");
            return serverName;
        }
        static async Task Main(string[] arg) // If Main uses any async methods, it must first be an async method itself.
        {
            // --- STEP 1: KICK OFF ALL TASKS ---
            // Notice: We are NOT using 'await' yet.
            // We are just starting the requests and holding the "Receipts" (Tasks).
            Task<string> userTask = FetchDataAsync("Users", 2000);
            Task<string> productTask = FetchDataAsync("Products", 5000);
            Task<string> analyticTask = FetchDataAsync("Analytics", 3000);

            // 2. RETRIEVE RESULTS
            // Wait time here is 2s 
            string userResult = await userTask;
            Console.WriteLine($"1. Got : {userResult}");

            // We are at 2s. Products takes 5s. We wait 3s more.
            string productResult = await productTask;
            Console.WriteLine($"2. Got : {productResult}");

            // This task finished already at 3s. We are at 5 secs right now.
            // Therefore this line happens instantly
            string analayticResult = await analyticTask;
            Console.WriteLine($"3. Got : {analayticResult}");

            //Now if we ran this in a traditional Synchronous manner, this task would have taken 2+3+5 = 10 seconds in total!
        }
    }
}