using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.CachedDataRepositories
{
    public class MessagePreviewPresentation
    {
        public long Id { get; set; }
        public long ChatId { get; set; }
        public int Date { get; set; }
        //EditDate=,
        public bool IsOutgoing { get; set; }
        public MessageSendingStatus SendingStatus { get; set; }
        public object PreviewContent { get; set; }
    }

    public enum MessageSendingStatus
    {
        Delivered,
        Error
    }
}
