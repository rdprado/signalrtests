using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServerTest.Controllers
{
    public interface ChatHubController
    {
        void StartSendingServerMessages(int msInterval);
        void StartSendingServerMessagesWithInterval(int intervalInMilliSecs, int maxMessages);

    }
}
