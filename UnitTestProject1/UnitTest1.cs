using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using River.ReceiveMail.WinService.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MailTask.Current.Send();
        }
    }
}
