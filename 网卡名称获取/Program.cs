using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 网卡名称获取
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("###################################################");
            //Console.WriteLine("STEP 1 ,choose the interface which can connect plc ");
            //Console.WriteLine("###################################################");
            //NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();//获取本地计算机上网络接口的对象
            ////Console.WriteLine("network cards count：" + adapters.Length);
            //Console.WriteLine();
            //int j = 1;
            //foreach (NetworkInterface adapter in adapters)
            //{
            //    if (adapter.OperationalStatus==OperationalStatus.Up)
            //    {
            //        Console.WriteLine((j++) + " ,Description：" + adapter.Description);
            //        IPInterfaceProperties property = adapter.GetIPProperties();
            //        foreach (UnicastIPAddressInformation ip in property.UnicastAddresses)
            //        {
            //            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //            {
            //                Console.WriteLine(ip.Address.ToString());
            //            }
            //        }

            //        // 格式化显示MAC地址                
            //        PhysicalAddress pa = adapter.GetPhysicalAddress();//获取适配器的媒体访问（MAC）地址
            //        byte[] bytes = pa.GetAddressBytes();//返回当前实例的地址
            //        StringBuilder sb = new StringBuilder();
            //        for (int i = 0; i < bytes.Length; i++)
            //        {
            //            sb.Append(bytes[i].ToString("X2"));//以十六进制格式化
            //            if (i != bytes.Length - 1)
            //            {
            //                sb.Append("-");
            //            }
            //        }
            //        Console.WriteLine("MAC address：" + sb);
            //    }

            //    //Console.WriteLine("标识符：" + adapter.Id);
            //    //Console.WriteLine("名称：" + adapter.Name);
            //    //Console.WriteLine("类型：" + adapter.NetworkInterfaceType);
            //    //Console.WriteLine("速度：" + adapter.Speed * 0.001 * 0.001 + "M");
            //    //Console.WriteLine("操作状态：" + adapter.OperationalStatus);
            //    //Console.WriteLine("MAC 地址：" + adapter.GetPhysicalAddress());


            //    Console.WriteLine();
            //}
            //Console.WriteLine("choose from 1 to " + (--j) + " :");
            //string x = Console.ReadLine();
            //Console.WriteLine("< "+adapters[Convert.ToInt32(x)-1].Description + " > is selected ;");

            //Console.WriteLine();
            //Console.WriteLine("#####################################################################");
            //Console.WriteLine("Step 2");
            //Console.WriteLine("Choose how many TIA instances you wanna run at same time ,which depends on your PC performance");
            //Console.WriteLine("16GB RAM ,I7 8 cores ,suggestion value would be 5  ,default Value 3 :");          
            //Console.WriteLine("#####################################################################");
            //int MaxThreads = Convert.ToInt16(Console.ReadLine());
            //Console.WriteLine("Now start with " + MaxThreads + " threads");

            //Console.ReadKey();


            //UnZipFloClass unzip = new UnZipFloClass();
            //string message="";
            //unzip.unZipFile(@".\ST2400_PLC_20200401_2232.zap14", @".\", ref message);

           
                Console.WriteLine("Task Start !");
                //DotaskWithThread();
                DOTaskWithAsync();
                Console.WriteLine("Task End !");
                Console.ReadLine();

            }

            public static async void DOTaskWithAsync()
            {

                Console.WriteLine("Await Taskfunction Start");
            for (int i = 0; i <= 10; i++)
            {
              //  Thread.Sleep(1000);
                Console.WriteLine("task before {0}  has been done!", i);
            }

            //await之前的代码其实和在主程序里执行没有区别
            await Task.Run(() => {
                    Dotaskfunction();
                });
            //await 之后的 代码，会在比较耗时的await代码完成后才会调用 

            for (int i = 0; i <= 10; i++)
            {
                //  Thread.Sleep(1000);
                Console.WriteLine("task after {0}  has been done!", i);
            }
            Console.WriteLine("Await Taskfunction end");

        }
        public static void Dotaskfunction()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("task {0}  has been done!", i);
            }

        }




        
    }
}
