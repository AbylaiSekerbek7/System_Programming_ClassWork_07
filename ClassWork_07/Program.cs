using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassWork_07
{
    internal class Program
    {
        static int Counter = 0;
        static Semaphore semaphore = null;
        static int cntThreadEnd = 0; // кол-во потоков, которые завершили работу

        static void Main(string[] args)
        {
            int ThCnt = 20;
            ThreadPool.SetMinThreads(ThCnt, ThCnt);
            semaphore = new Semaphore(0, ThCnt);

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < ThCnt; ++i)
            {
                ThreadPool.QueueUserWorkItem(ThreadProc);
                //ThreadProc(null);
            }

            /*for (int i = 0; i < ThCnt; ++i)
            {
                semaphore.WaitOne(); // Ожидание завершения очередного потока
            }*/
            while (cntThreadEnd < ThCnt) { Thread.Sleep(0); }
            sw.Stop();

            //Thread.Sleep(2000); // Time-out ожидание завершения потоков
            Console.WriteLine($"Counter = {Counter} and Time execution {sw.ElapsedTicks} tiks, {sw.ElapsedMilliseconds} msec");
            Console.ReadLine();
        }

        static Mutex mutex = new Mutex(false);
        static AutoResetEvent autoReset = new AutoResetEvent(true);
        static object forCounter = new object();

        static void ThreadProc(object obj)
        {
            for (int i = 0; i < 10_000; ++i)
            {
                // 1 - Variant with Mutex 
                /*
                mutex.WaitOne();
                {
                    Counter++;
                }
                mutex.ReleaseMutex();
                */

                // 2 - Variant with AutoReset
                /*
                autoReset.WaitOne(); // ==> autoReset.Reset();
                {
                    Counter++;
                }
                autoReset.Set();
                */

                // 3 - Variant with Interlocked
                //Interlocked.Increment(ref Counter);

                // 4 - Variant with lock()
                /*
                lock (forCounter)
                {
                    Counter++;
                }
                */

                // 5 - Variant with Monitor
                Monitor.Enter(forCounter);
                Counter++;
                Monitor.Exit(forCounter);

            }
            //semaphore.Release();
            Interlocked.Increment(ref cntThreadEnd);
        }
    }
}