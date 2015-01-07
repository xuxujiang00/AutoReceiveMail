using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace River.ReceiveMail.Helper
{
    public static class ConfigHelper
    {
        public static string MAIL_Accounts;
        public static int IntervalTimer;
        public static string MAIL_FileSavePath;

        static ConfigHelper()
        {
            try
            {
                MAIL_Accounts = ConfigurationManager.AppSettings["Accounts"];
                IntervalTimer = int.Parse(ConfigurationManager.AppSettings["IntervalTimer"]);
                MAIL_FileSavePath = ConfigurationManager.AppSettings["FileSavePath"];
            }
            catch
            {
                throw new ArgumentException("服务配置错误，请检查config配置文件");

            }
        }
    }
}
