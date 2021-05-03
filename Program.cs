using System;
using System.Threading;

namespace GP20_Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = new Mutex(false, "com.lynkanrex");

            new Thread(() =>
            {
                while (true)
                {
                    if (mutex.WaitOne(2000))
                    {
                        Console.WriteLine("Starting program...");
                        Console.WriteLine("Welcome! Press any key to exit");
                        Console.ReadLine();
                        mutex.ReleaseMutex();
                    }
                    else
                    {
                        Console.WriteLine("Warning, another instance of this program" +
                                          "is already running.");
                        break;
                    }
                }
            }).Start();
        }
    }
}
