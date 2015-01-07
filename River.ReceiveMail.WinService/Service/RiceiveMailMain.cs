using River.ReceiveMail.WinService.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace River.ReceiveMail.WinService
{
    partial class RiceiveMailMain : ServiceBase
    {
        public RiceiveMailMain()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            //MailTask.Current.Start();
            MailTask.Current.Send();
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            //MailTask.Current.Stop();
        }

        public void Start()
        {
            MailTask.Current.Start();
        }
    }
}
