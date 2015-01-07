using River.ReceiveMail.WinService.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace River.ReceiveMail.WinService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[] 
            //{ 
            //    new RiceiveMailMain()
            //};
            //ServiceBase.Run(ServicesToRun);
            MailTask.Current.Send();
        }
    }
}
