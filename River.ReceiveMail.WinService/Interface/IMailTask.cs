using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace River.ReceiveMail.WinService.Interface
{
    public interface IMailTask
    {
        string TaskName { get; }

        void Send();

        void Start();

        void Stop();
    }
}
