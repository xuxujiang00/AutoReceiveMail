using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace River.ReceiveMail.Helper.log
{
    public class LogHelper
    {
        static readonly ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Debug(object message)
        {
            log.Debug(message);
        }

        public static void Debug(object message, Exception exception)
        {
            log.Debug(message, exception);
        }

        public static void Error(object message)
        {
            log.Error(message);
        }

        public static void Error(string modelType, string op, string message, Exception exception)
        {
            string temp = string.Format("模块名称:{0}\r\n操作：{1}\r\n消息：{2}\r\n", modelType, op, message);
            InternelError(temp, exception);
        }

        private static void InternelError(object message, Exception exception)
        {
            log.Error(message, exception);
        }

        public static void Warn(object message)
        {
            log.Warn(message);
        }

        public static void Warn(object message, Exception exception)
        {
            log.Warn(message, exception);
        }

        public static void Info(object message)
        {
            log.Info(message);
        }

        public static void Info(object message, Exception exception)
        {
            log.Info(message, exception);
        }

        public static void Fatal(object message)
        {
            log.Fatal(message);
        }

        public static void Fatal(object message, Exception exception)
        {
            log.Fatal(message, exception);
        }
    }
}
