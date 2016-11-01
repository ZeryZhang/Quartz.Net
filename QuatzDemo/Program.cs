using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using log4net;
using Topshelf;

namespace QuartzDemo
{


    /// <summary>
    /// 参考文章 Quartz http://www.cnblogs.com/jys509/p/4628926.html
    ///  Topshelf  http://www.cnblogs.com/jys509/p/4614975.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            //Windowns服务调度
            //HostFactory.Run(x =>
            //{
            //    x.UseLog4Net();
            //    x.Service<WindownsService>();
            //    x.SetDescription("Quartz定时调度服务");
            //    x.SetDisplayName("Quartz Job");
            //    x.SetServiceName("Quartz Job Service");
            //});


            try
            {
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();
            }
            catch (SchedulerException ex)
            {
                Console.WriteLine(ex);
            }
            
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 定义Windows服务 
    /// </summary>
    public class WindownsService : ServiceControl, ServiceSuspend
    {
        public IScheduler scheduler;
        public WindownsService()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }

        public bool Start(HostControl hostControl)
        {
            scheduler.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {   //强制停止
            scheduler.Shutdown(false);
            return true;
        }

        public bool Continue(HostControl hostControl)
        {
            scheduler.ResumeAll();
            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            scheduler.PauseAll();
            return true;
        }

    }
}
