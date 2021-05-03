using System;
using System.Threading;

namespace GP20_Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong a = 0, b = 0, ab = 0;
            object _lock = "true";
            
            new Thread(() =>
            {
                while(true)
                {
                    lock (_lock)
                    {
                        a++;
                        ab++;
                    }
                }
            }).Start();
            new Thread(() =>
            {
                while(true)
                {
                    lock (_lock)
                    {
                        b++;
                        ab++;
                    }
                }
            }).Start();
            new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine($"a: {a}, b: {b}, ab: {ab}");
                    Thread.Sleep(100);
                }
            }).Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
