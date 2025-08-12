using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.LightChatsUpdatesDispatcher
{
    public class ChatContentUpdate<TContent>
    {
        public long ChatId { get; set; }
        public TContent Content { get; set; }
    }
}
