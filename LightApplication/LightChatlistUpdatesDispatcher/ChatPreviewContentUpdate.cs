using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.LightChatlistUpdatesDispatcher
{
    public class ChatPreviewContentUpdate<TContent>
    {
        public long ChatId { get; set; }
        public TContent Content { get; set; }
    }
}
