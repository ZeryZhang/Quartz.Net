using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Job;
using log4net;
namespace QuartzDemo
{

    public class PrintJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            ILog log = LogManager.GetLogger(typeof(PrintJob));
            log.Info(" PrintJob 任务执行成功 ");
            Console.WriteLine("This Print Job");
        }

    }
}
