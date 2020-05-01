using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace cmd命令
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Zap14List = new List<string>();
            Zap14List.Add(@"G:\ST5700\ST5720_20200328_1547.zap14");
            Zap14List.Add(@"G:\ST5700\ST5720_20200328_1548.zap14");

            
            Task<string> resultStr=RunCMDCommand(Zap14List);
          
            Console.WriteLine(resultStr.Result);
            Console.ReadKey();
        }
        public static Task<string> RunCMDCommand(List<string> Zap14List)
        {

           Task<string> ts= Task.Run(() => {
                using (Process pc = new Process())
                {
                    pc.StartInfo.FileName = "cmd.exe";
                    pc.StartInfo.CreateNoWindow = true;//隐藏窗口运行
                    pc.StartInfo.RedirectStandardError = true;//重定向错误流
                    pc.StartInfo.RedirectStandardInput = true;//重定向输入流
                    pc.StartInfo.RedirectStandardOutput = true;//重定向输出流
                    pc.StartInfo.UseShellExecute = false;
                    pc.Start();
                   // int lenght = command.Length;
                    foreach (string com in GetCommandList(Zap14List))
                    {
                        pc.StandardInput.WriteLine(com);//输入CMD命令
                    }
                    pc.StandardInput.WriteLine("exit");//结束执行，很重要的
                    pc.StandardInput.AutoFlush = true;

                    var x = pc.StandardOutput.ReadToEnd();//读取结果 

                    pc.WaitForExit();
                    pc.Close();

                    return x;
                }

            });
            return ts;
            
        }
        public static List<string> GetCommandList(List<string> Zap14List)
        {
            string TargetFolder = @"D:\tmp\";

            List<string> CommandList = new List<string>();
            foreach (var Zap14 in Zap14List)
            {
                string com = @"c: && cd C:\Program Files\7-Zip && 7z.exe x """ + Zap14 + @"""  -o""" + TargetFolder + Zap14.Split('\\')[Zap14.Split('\\').Length - 1].Split('.')[0] + @""" -aoa";
                CommandList.Add(com);
            }

            return CommandList;
        }
    }
}
