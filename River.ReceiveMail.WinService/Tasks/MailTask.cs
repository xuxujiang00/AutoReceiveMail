using LumiSoft.Net.IMAP;
using LumiSoft.Net.IMAP.Client;
using LumiSoft.Net.Mail;
using LumiSoft.Net.Mime;
using LumiSoft.Net.MIME;
using LumiSoft.Net.POP3.Client;
using River.ReceiveMail.Helper;
using River.ReceiveMail.Helper.log;
using River.ReceiveMail.Model;
using River.ReceiveMail.WinService.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace River.ReceiveMail.WinService.Tasks
{
    public class MailTask : IMailTask
    {
        #region --- 单例 ---
        public static readonly MailTask Current = new MailTask();

        #endregion
        private Thread _MyThread = null;

        public string TaskName
        {
            get;
            private set;
        }

        private Mime My_MIME = null;

        private MailTask()
        {
            TaskName = "邮件接收服务";
        }
        #region --- start stop ---
        public void Start()
        {
            if (_MyThread == null)
                _MyThread = new Thread(Send);
            _MyThread.IsBackground = true;
            _MyThread.Start();
            LogHelper.Info("邮件接收服务---启动");
        }

        public void Stop()
        {
            if (_MyThread != null)
                _MyThread.Abort();
            LogHelper.Info("邮件接收服务---停止");
        }
        #endregion

        public void Send()
        {
            LogHelper.Info("邮件接收服务---开始接收");
            IList<AccountModel> models = XmlHelper.ConverToAccountModel(ConfigHelper.MAIL_Accounts);
            while (true)
            {
                try
                {
                    foreach (AccountModel item in models)
                    {
                        ServiceEmailToLocalhost(item);
                    }
                }
                catch (Exception ex)
                {
                    //throw ex;
                    LogHelper.Error("异常信息，" + ex.Message);
                }
                My_MIME = null;
                GC.Collect();
                Thread.Sleep(1000 * ConfigHelper.IntervalTimer);
            }
        }

        public void ServiceEmailToLocalhost(AccountModel mailInfo)
        {
            using (POP3_Client pop3 = new POP3_Client())
            {
                //与Pop3服务器建立连接
                pop3.Connect(mailInfo.Pop3Server, mailInfo.Pop3Port, mailInfo.Pop3UserSsl);
                //验证身份
                pop3.Authenticate(mailInfo.UserName, mailInfo.PassWord, false);
                //获取邮件信息列表
                POP3_ClientMessageCollection infos = pop3.Messages;
                foreach (POP3_ClientMessage info in infos)
                {
                    try
                    {
                        //每封Email会有一个在Pop3服务器范围内唯一的Id,检查这个Id是否存在就可以知道以前有没有接收过这封邮件
                        //if (gotEmailIds.Contains(info.UID))
                        //    continue;

                        //获取这封邮件的内容
                        //记录这封邮件的Id
                        //gotEmailIds.Add(info.UID);

                        //解析从Pop3服务器发送过来的邮件信息
                        My_MIME = null;
                        My_MIME = Mime.Parse(info.MessageToByte());

                        string fileName = My_MIME.MainEntity.Date.Date.ToString("yyyy-MM-dd");
                        string filePathLong = Path.Combine(ConfigHelper.MAIL_FileSavePath, fileName);
                        FileHelper.CreateFile(filePathLong);
                        string subject = My_MIME.MainEntity.Subject.Replace(':', ' ');
                        if (subject.Length > 10)
                            subject = subject.Substring(0, 10);
                        subject += "_" + info.UID + ".eml";

                        FileHelper.SaveFileFromBytes(My_MIME.ToByteData(), Path.Combine(filePathLong, subject));
                        info.MarkForDeletion();
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(string.Format("账号：{0}保存eml文件出错,,错误信息:{1}", mailInfo.UserName, ex.Message));
                    }
                }
            }
        }
    }
}
