using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.UpdateDispatchers
{
    public interface IChatUpdatesDispatcher
    {
        void SendChatLoadedUpdate();
    }
}
