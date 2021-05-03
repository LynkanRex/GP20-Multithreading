using System;
using System.Threading;

namespace GP20_Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            var semaphore = new Semaphore(3, 3,"com.lynkanrex.semaphore");

            new Thread(() =>
            {
                while (true)
                {
                    if (semaphore.WaitOne(2000))
                    {
                        Console.WriteLine("Starting program...");
                        Console.WriteLine("Welcome! Press any key to exit");
                        Console.ReadLine();
                        semaphore.Release();
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
