using System;
using System.Collections.Generic;
using System.Text;

namespace LightApplication.LightChatsRequests
{
    public class MessageResult
    {
        public long Id { get; set; }
        public long ChatId { get; set; }
        public long SenderUserId { get; set; }
        public int Date { get; set; }//??
        public int EditDate { get; set; }//??

        public bool IsOutgoing { get; set; }
        public bool IsContainUnreadMentions{get;set;}
        public bool IsPinned { get; set; }

        public bool IsSendedOffline { get; set; }

        public bool CanBeSaved { get; set; }

        public MessageSendingState SendingState { get; set; }

        //about user
        public bool ContainsUnreadMention { get; set; }

        public MessageContentType ContentType { get; set; }
        public object MessageContent { get; set; }
    }

    

    public enum MessageContentType
    {
        Text,
        Photo
    }

    public enum MessageSendingState
    {
        Pending,
        Failed,
        Sent
    };
    
    
    
    
}
