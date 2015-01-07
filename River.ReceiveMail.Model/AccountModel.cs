using LumiSoft.Net.POP3.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace River.ReceiveMail.Model
{
    public class AccountModel
    {
        public string Pop3Server { set; get; }
        public int Pop3Port { set; get; }
        public bool Pop3UserSsl { set; get; }
        public string UserName { set; get; }
        public string PassWord { set; get; }

        public POP3_Client _POP3Client { set; get; }
    }
}
