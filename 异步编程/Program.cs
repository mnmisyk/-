using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace 异步编程
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDownloadString ds = new MyDownloadString();
            ds.DoRun();
            Console.ReadKey();
        }
    }

    class MyDownloadString
    {
        Stopwatch sw = new Stopwatch();
        public void DoRun()
        {
            const int LargeNumber = 6000000;
            sw.Start();

            Task<int> t1 = CountCharacterAsync(1, "http://www.microsoft.com");
           // t1.Wait(); 等待这个任务执行完成再去执行其他
            Task<int> t2 = CountCharacterAsync(2, "http://www.illustratedcsharp.com");
           // t2.Wait();
            CountToAlargeNumber(1, LargeNumber);
            CountToAlargeNumber(2, LargeNumber);
            CountToAlargeNumber(3, LargeNumber);
            CountToAlargeNumber(4, LargeNumber);
            
            Console.WriteLine("chars in www.microsoft.com : {0}", t1.Result);
            Console.WriteLine(" chars in www.illustatecsharp.com : {0}", t2.Result);

        }
        //async 相当于一个标志，标志这个是异步方法，await 指明需要异步执行的地方 ，一个
        //异步方法可以包含任意多个await表达式，如果一个不包括编译器会报警,

        //异步方法的三种返回类型
        //Task<T> ，方法返回值，使用Task.Result获得这个返回值
        //Task ，如果调用方法不需要从异步方法中返回某个值，但需要检查异步方法的状态,此时使用Task，这是即使异步方法return了某个值，此时也不会获取到
        //Void ，只是调用异步方法，没有任何交互
        // await 指定一个异步执行的任务（TASK）,创建一个Task的最简单方法是 Task.run() ,它是在不同线程上运行方法
        //Task.Delay 不同于thread.sleep 不会阻塞线程，线程可以继续处理其他工作

        private async Task<int> CountCharacterAsync(int id ,string site)
        {
            WebClient wc = new WebClient();
            Console.WriteLine("starting call {0} : {1} ms", 
                id, sw.Elapsed.TotalMilliseconds);
            string result = await wc.DownloadStringTaskAsync(new Uri(site));
      
            Func<int, int> nf = new Func<int, int>(get10);
            await Task.Run(() =>  get10(2));   // 使用lambada表达式逃避task类型的约束

            Console.WriteLine(" Call {0} completed : {1} ms",
                id, sw.Elapsed.TotalMilliseconds);
            return result.Length;
           
        }

        private void CountToAlargeNumber(int id ,int value)
        {
            for (long i = 0; i < value; i++) ;
            
                Console.WriteLine(" End counting {0} : {1} ms ",id,sw.Elapsed.TotalMilliseconds );
           
        }
        private int get10(int x)
        {
            return 10+x;
        }

    }
}
